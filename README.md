# 🛠 Maintenance API

API REST en ASP.NET Core pour la gestion des interventions, clients et techniciens.  
C'est du .NET, donc attendez-vous à quelques humeurs de diva ✨.

---

## 📬 Endpoints Disponibles


## 🔐 POST /register

Créer un compte utilisateur.

### 📥 Requête :
```json
{
  "email": "technicien3@maintenance.com",
  "password": "MotDePasseFort123!",
  "role": "Technicien/Admin/Client"
}
```

## 🔐 POST /login

Connexion d’un utilisateur existant.  
Retourne un token JWT à utiliser dans les requêtes protégées.

### 📥 Requête :
```json
{
  "email": "technicien3@maintenance.com",
  "password": "MotDePasseFort123!"
}
```

## 🧰 POST /api/Service

Créer un type de service (ex : Maintenance préventive, Dépannage, Inspection…).

### 📥 Requête :
```json
{
  "type": "Des trucs de con"
}
```

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
```
