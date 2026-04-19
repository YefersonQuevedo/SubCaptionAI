# SubCaptionAI

Aplicación de escritorio para Windows que transcribe videos y audio usando IA (Whisper), genera subtítulos `.srt` y permite elegir el idioma de salida entre más de 69 idiomas.

---

## Requisitos previos

### 1. Python 3.8 o superior
Descárgalo desde [python.org](https://www.python.org/downloads/).  
Durante la instalación activa la opción **"Add Python to PATH"**.

### 2. Instalar Whisper y dependencias
Abre una terminal y ejecuta:

```bash
pip install openai-whisper
pip install torch
```

> Si tienes GPU NVIDIA y quieres usar CUDA (más rápido):
> ```bash
> pip install torch torchvision torchaudio --index-url https://download.pytorch.org/whl/cu118
> ```

### 3. FFmpeg
Whisper lo necesita para leer archivos de video/audio.

1. Descárgalo desde [ffmpeg.org](https://ffmpeg.org/download.html)
2. Extrae el archivo y copia la carpeta `bin` en algún lugar fijo (ej: `C:\ffmpeg\bin`)
3. Agrégalo al PATH de Windows:
   - Busca "Variables de entorno" en el menú inicio
   - En "Variables del sistema" → `Path` → Agregar `C:\ffmpeg\bin`

### 4. .NET 8 Runtime (para ejecutar la app)
Descárgalo desde [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0).

---

## Instalación de SubCaptionAI

1. Descarga o clona este repositorio:
   ```bash
   git clone https://github.com/YefersonQuevedo/SubCaptionAI.git
   ```
2. Abre la carpeta descargada.

---

## Cómo usar

### Paso 1 — Configurar rutas

Al abrir la app verás dos campos en la parte superior:

| Campo | Qué poner |
|---|---|
| **Python** | `python` (si está en PATH) o la ruta completa, ej: `C:\Python312\python.exe` |
| **Script** | Ruta al archivo `transcribe.py` incluido en la carpeta del proyecto |

### Paso 2 — Elegir carpeta de salida

Haz clic en **"Elegir..."** y selecciona dónde quieres que se guarden los archivos `.txt` y `.srt`.

### Paso 3 — Elegir opciones

| Opción | Descripción |
|---|---|
| **Modelo** | `tiny` (rápido, menos preciso) → `large` (lento, muy preciso) |
| **Dispositivo** | `cpu` (cualquier PC) o `cuda` (solo GPU NVIDIA) |
| **Modo** | Rápido / Balanceado / Preciso |
| **Idioma** | El idioma en que quieres la transcripción/traducción. Usa **Auto-detectar** si no sabes el idioma del video |

### Paso 4 — Agregar archivos

Haz clic en **"➕ Agregar archivos"** y selecciona uno o varios videos/audios.

Formatos soportados: `.mp4`, `.mkv`, `.mov`, `.avi`, `.wav`, `.mp3`

### Paso 5 — Transcribir

Haz clic en **"▶ TRANSCRIBIR"**.

La app procesará todos los archivos en orden y mostrará el progreso en la lista y en el registro inferior.

Al terminar encontrarás en la carpeta de salida:
- `nombre_video.txt` — texto plano de la transcripción
- `nombre_video.srt` — subtítulos con marcas de tiempo listos para usar en cualquier reproductor

---

## Modelos disponibles

| Modelo | Velocidad | Precisión | VRAM recomendada |
|---|---|---|---|
| tiny | ⚡⚡⚡ | Básica | ~1 GB |
| base | ⚡⚡ | Buena | ~1 GB |
| small | ⚡ | Muy buena | ~2 GB |
| medium | Lento | Excelente | ~5 GB |
| large | Muy lento | Máxima | ~10 GB |

> Para la mayoría de casos **base** o **small** es suficiente.

---

## Solución de problemas

**"No se encuentra python"**  
→ Verifica que Python esté instalado y en el PATH. Prueba escribir `python --version` en una terminal.

**"No se encuentra ffmpeg"**  
→ Verifica que ffmpeg esté en el PATH. Prueba escribir `ffmpeg -version` en una terminal.

**El proceso termina con error sin mensaje claro**  
→ Revisa el registro (panel negro inferior), generalmente indica si falta alguna librería.

**La transcripción sale en el idioma equivocado**  
→ Selecciona el idioma correcto en el combo "Idioma" o usa "Auto-detectar".

---

## Licencia

Todos los derechos reservados © Yeferson Quevedo. No está permitido copiar, modificar, distribuir ni usar este software sin autorización escrita del autor.
