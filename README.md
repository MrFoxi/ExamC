# 🛠 Maintenance API

API REST en ASP.NET Core pour la gestion des interventions, clients et techniciens.  
C'est du .NET, donc attendez-vous à quelques humeurs de diva ✨.

---

## 📬 Endpoints Disponibles

### 🔧 POST /api/Intervention

**Créer une nouvelle intervention**

#### ✅ Requête :
```json
{
  "clientId": 1,
  "technicianIds": [2, 3],
  "type": "Maintenance préventive",
  "date": "2025-05-10T10:00:00"
}
