# transcribe.py
import argparse
import os
import sys
import whisper

def transcribe_video(video_path: str, out_dir: str, model_name: str, device: str, language: str):
    if not os.path.exists(video_path):
        print(f"[ERROR] No existe: {video_path}", flush=True)
        return 1

    base = os.path.splitext(os.path.basename(video_path))[0]
    os.makedirs(out_dir, exist_ok=True)
    out_txt = os.path.join(out_dir, base + ".txt")
    out_srt = os.path.join(out_dir, base + ".srt")

    print(f"[INFO] Cargando modelo '{model_name}' en {device} ...", flush=True)
    model = whisper.load_model(model_name, device=device)

    print(f"[INFO] Transcribiendo: {video_path}", flush=True)
    use_fp16 = (device == "cuda")

    # Sugerencias para estabilidad en archivos largos:
    result = model.transcribe(
        video_path,
        fp16=use_fp16,
        language=language,                 # "es" por defecto
        verbose=False,
        condition_on_previous_text=False,  # útil en audios largos
        temperature=0.0                    # hace la salida más estable
    )

    text = result.get("text", "") or ""
    with open(out_txt, "w", encoding="utf-8") as f:
        f.write(text)
    print(f"[OK] Guardado TXT: {out_txt}", flush=True)

    # Construir SRT sencillo a partir de segments
    def format_ts(t):
        # segundos -> "HH:MM:SS,mmm"
        ms = int(round(t * 1000))
        h = ms // 3600000; ms %= 3600000
        m = ms // 60000;   ms %= 60000
        s = ms // 1000;    ms %= 1000
        return f"{h:02d}:{m:02d}:{s:02d},{ms:03d}"

    segments = result.get("segments", []) or []
    with open(out_srt, "w", encoding="utf-8") as f:
        for i, seg in enumerate(segments, start=1):
            start = format_ts(seg["start"])
            end   = format_ts(seg["end"])
            txt   = (seg.get("text") or "").strip()
            if not txt:
                continue
            f.write(f"{i}\n{start} --> {end}\n{txt}\n\n")
    print(f"[OK] Guardado SRT: {out_srt}", flush=True)

    return 0

def main():
    parser = argparse.ArgumentParser(description="Transcribe 1..N videos con Whisper.")
    parser.add_argument("videos", nargs="+", help="Rutas de archivo .mp4/.wav/etc.")
    parser.add_argument("--out", default=".", help="Carpeta de salida (por defecto, actual).")
    parser.add_argument("--model", default="base", help="Modelo (tiny/base/small/medium/large).")
    parser.add_argument("--device", default="cpu", choices=["cpu","cuda"], help="cpu o cuda.")
    parser.add_argument("--language", default="es", help="Idioma ISO-639-1 (ej: es, en, pt...).")
    args = parser.parse_args()

    rc = 0
    for v in args.videos:
        try:
            rc |= transcribe_video(v, args.out, args.model, args.device, args.language)
        except Exception as e:
            print(f"[EXCEPTION] {v}: {e}", flush=True)
            rc = 1
    sys.exit(rc)

if __name__ == "__main__":
    main()
