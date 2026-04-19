# Idea: Subtítulos en Tiempo Real (RealTimeSubs)

Aplicación separada de SubCaptionAI que traduce y subtitula en tiempo real
cualquier cosa que suene en el PC usando audio loopback.

## Concepto

```
PC reproduce video/stream/juego
    ↓
VB-Audio Virtual Cable (captura audio del sistema)
    ↓ (aparece como micrófono virtual)
WhisperLive escucha el audio
    ↓
Ventana flotante con subtítulos traducidos en pantalla
```

## Casos de uso

- Series en Netflix/Prime en inglés → subtítulos en español en tiempo real
- Streams de Twitch en cualquier idioma → traducción al vuelo
- Reuniones de Zoom en inglés → subtítulos flotantes encima de la ventana
- Cualquier video de YouTube sin subtítulos

## Hardware requerido

- RTX 3090 (24GB VRAM) — suficiente para large-v3-turbo con ~1-2s de latencia
- 32GB RAM — más que suficiente

## Stack técnico

| Componente | Herramienta |
|---|---|
| Captura de audio del sistema | VB-Audio Virtual Cable (gratis) |
| Motor de transcripción/traducción | WhisperLive + faster-whisper |
| Modelo recomendado | large-v3-turbo (mejor velocidad/calidad) |
| UI subtítulos | Ventana flotante always-on-top (C# WinForms o Python tkinter) |

## Lo que tendría la app

- [ ] Selector de dispositivo de audio (micrófono real o cable virtual)
- [ ] Selector de idioma origen y destino
- [ ] Ventana de subtítulos flotante siempre encima de otras apps
- [ ] Tamaño y color de texto configurable
- [ ] Botón iniciar/detener
- [ ] Historial de lo transcripto

## Instalación estimada (cuando se implemente)

```bash
pip install faster-whisper
pip install whisperlive
# + instalar VB-Audio Virtual Cable desde vb-audio.com
```

## Referencias

- WhisperLive: https://github.com/collabora/WhisperLive
- VB-Audio Virtual Cable: https://vb-audio.com/Cable/
- faster-whisper: https://github.com/SYSTRAN/faster-whisper
- Latencia estimada RTX 3090 con large-v3-turbo: ~1-2 segundos
