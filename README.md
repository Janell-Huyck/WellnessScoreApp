# Wellness Score App

A .NET MAUI app that calculates a Daily Wellness Score (0–100) from lifestyle inputs and shows a status plus gender-aware recommendations.

---

## User inputs

| Input | Type | Range / options | Default |
|-------|------|-----------------|--------|
| **Gender** | Two tappable images (male / female) | Male, Female | — |
| **Sleep hours** | Slider | 0–12 h | 7 h |
| **Stress level** | Slider | 0–10 (calm → stressed) | 4 |
| **Activity minutes** | Slider | 0–120 min | 30 min |

---

## How the app responds

**Formula:** `Wellness Score = (SleepHours × 8) − (StressLevel × 5) + (ActivityMinutes × 0.5)`  
**Display:** Score is clamped to 0–100 and rounded to a whole number.

**Classification:**

| Score | Status   |
|-------|----------|
| 80–100 | Excellent |
| 60–79  | Good     |
| 40–59  | Fair     |
| 0–39   | Poor     |

---

## Recommendations by status and gender

What the app shows depends on **status** (from score) and **gender** (from selected image).

### Excellent (80–100)

| Gender | Recommendation |
|--------|----------------|
| **Male** | You're a champion. Keep crushing those weights, eating steak, and leading. Maybe grunt a little louder so everyone knows you're winning. |
| **Female** | You're doing so well! Remember to stay pretty while you exercise—maybe some yoga in a cute outfit. Don't forget to smile; it's good for your face. |

### Good (60–79)

| Gender | Recommendation |
|--------|----------------|
| **Male** | You're slipping. Man up: go to bed earlier, do some push-ups, and drink water like a normal human. No excuses. |
| **Female** | Aww, rough day? Try a nice bubble bath, a balanced breakfast so you don't get hangry, and a little walk. Maybe paint your nails after—self-care! |

### Fair (40–59)

| Gender | Recommendation |
|--------|----------------|
| **Male** | Get it together. More sleep, less caffeine, and move your body. Sitting on the couch isn't a hobby. |
| **Female** | Sweetie, you're run ragged. Less screen time, more meditation and journaling. Have you tried a calming face mask? So relaxing. |

### Poor (0–39)

| Gender | Recommendation |
|--------|----------------|
| **Male** | Rest day. No heavy lifting. Hydrate, take a short walk, and don't be a hero. The gym will still be there tomorrow. |
| **Female** | You should wear extra pink ribbons in your hair today. Cute little girly girls like you should take good care of their hair. Maybe a nap, then some gentle yoga. So delicate. |
