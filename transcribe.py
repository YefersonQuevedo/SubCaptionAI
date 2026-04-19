# transcribe.py
import argparse
import os
import sys
import whisper

# Configuraciones por modo
MODES = {
    "rapido": dict(
        beam_size=1,
        word_timestamps=False,
        temperature=0.0,
        condition_on_previous_text=False,
    ),
    "balanceado": dict(
        beam_size=5,
        word_timestamps=False,
        temperature=0.0,
        condition_on_previous_text=False,
        no_speech_threshold=0.6,
        compression_ratio_threshold=2.4,
        logprob_threshold=-1.0,
    ),
    "preciso": dict(
        beam_size=5,
        word_timestamps=True,
        temperature=0.0,
        condition_on_previous_text=False,
        no_speech_threshold=0.6,
        compression_ratio_threshold=2.4,
        logprob_threshold=-1.0,
        initial_prompt="Clase académica. Vocabulario técnico educativo.",
    ),
}

def transcribe_video(video_path: str, out_dir: str, model_name: str, device: str, language: str, mode_cfg: dict, model=None):
    if not os.path.exists(video_path):
        print(f"[ERROR] No existe: {video_path}", flush=True)
        return 1, model

    base = os.path.splitext(os.path.basename(video_path))[0]
    filename = os.path.basename(video_path)
    os.makedirs(out_dir, exist_ok=True)
    out_txt = os.path.join(out_dir, base + ".txt")
    out_srt = os.path.join(out_dir, base + ".srt")

    print(f"[PROGRESS] {filename} | Cargando modelo | Preparando...", flush=True)

    if model is None:
        print(f"[INFO] Cargando modelo '{model_name}' en {device} ...", flush=True)
        model = whisper.load_model(model_name, device=device)

    print(f"[PROGRESS] {filename} | Transcribiendo | Procesando audio...", flush=True)
    print(f"[INFO] Transcribiendo: {video_path}", flush=True)

    use_fp16 = (device == "cuda")
    result = model.transcribe(
        video_path,
        fp16=use_fp16,
        language=language,
        verbose=False,
        **mode_cfg
    )

    text = result.get("text", "") or ""

    print(f"[PROGRESS] {filename} | Guardando archivos | Generando TXT y SRT...", flush=True)

    with open(out_txt, "w", encoding="utf-8") as f:
        f.write(text)
    print(f"[OK] Guardado TXT: {out_txt}", flush=True)

    def format_ts(t):
        ms = int(round(t * 1000))
        h = ms // 3600000; ms %= 3600000
        m = ms // 60000;   ms %= 60000
        s = ms // 1000;    ms %= 1000
        return f"{h:02d}:{m:02d}:{s:02d},{ms:03d}"

    segments = result.get("segments", []) or []
    with open(out_srt, "w", encoding="utf-8") as f:
        idx = 1
        for seg in segments:
            txt = (seg.get("text") or "").strip()
            if not txt:
                continue
            start = format_ts(seg["start"])
            end   = format_ts(seg["end"])
            f.write(f"{idx}\n{start} --> {end}\n{txt}\n\n")
            idx += 1
    print(f"[OK] Guardado SRT: {out_srt}", flush=True)

    print(f"[PROGRESS] {filename} | ✓ Completado | 100%", flush=True)

    return 0, model

def main():
    parser = argparse.ArgumentParser(description="Transcribe 1..N videos con Whisper.")
    parser.add_argument("videos", nargs="+", help="Rutas de archivo .mp4/.wav/etc.")
    parser.add_argument("--out",      default=".",          help="Carpeta de salida.")
    parser.add_argument("--model",    default="base",       help="Modelo (tiny/base/small/medium/large).")
    parser.add_argument("--device",   default="cpu",        choices=["cpu", "cuda"])
    parser.add_argument("--language", default="es",         help="Idioma ISO-639-1 (ej: es, en, pt...).")
    parser.add_argument("--mode",     default="balanceado", choices=["rapido", "balanceado", "preciso"],
                        help="Modo de calidad: rapido, balanceado, preciso.")
    args = parser.parse_args()

    mode_cfg = MODES[args.mode].copy()
    print(f"[INFO] Modo: {args.mode} | Modelo: {args.model} | Idioma: {args.language}", flush=True)

    rc = 0
    model = None

    for i, v in enumerate(args.videos, 1):
        try:
            print(f"\n[INFO] === Procesando archivo {i}/{len(args.videos)} ===", flush=True)
            ret_code, model = transcribe_video(v, args.out, args.model, args.device, args.language, mode_cfg, model)
            rc |= ret_code
        except Exception as e:
            filename = os.path.basename(v)
            print(f"[PROGRESS] {filename} | ✗ Error | {str(e)}", flush=True)
            print(f"[EXCEPTION] {v}: {e}", flush=True)
            rc = 1
    sys.exit(rc)

if __name__ == "__main__":
    main()
