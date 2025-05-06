# ♻️ Compostaqui.API

> API oficial do projeto **Compostaqui** — promovendo sustentabilidade com tecnologia.  
> Este repositório contém o código-fonte da **API REST** do sistema.

⚠️ **Atenção:**  
Alterações no código deste repositório devem ser feitas **exclusivamente pelos responsáveis pelo back-end** do projeto.

---

## 📦 Tecnologias Utilizadas

- ASP.NET Core
- Dapper
- Microsoft Sql Server
- Google Cloud Platform (GCP)
- GitHub Actions (CI/CD)

---

## 🚀 Deploy

A aplicação está hospedada na **Google Cloud** e conta com um processo de deploy **automatizado via pipeline CI/CD**.

- Push na branch `develop` → deploy automático para o ambiente de **Homologação**.
- Push na branch `main` → deploy automático para o ambiente de **Produção**.

📡 **URL de Homologação:**  
[https://api-hml-compostaqui-4v5phq6s2a-uc.a.run.app/](https://api-hml-compostaqui-4v5phq6s2a-uc.a.run.app/)

---

## 📚 Documentação da API

A API utiliza **Swagger** para disponibilizar a documentação interativa dos endpoints.

- Acesse a [interface em `/swagger`](https://api-hml-compostaqui-4v5phq6s2a-uc.a.run.app/swagger)

---

## 🔍 Endpoint Raiz (`/`)

O [path raiz da API](https://api-hml-compostaqui-4v5phq6s2a-uc.a.run.app/) (`/`) retorna informações úteis sobre a build atual.
