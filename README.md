# ContactManagement - ASP.NET Core Web Application / Aplicação Web ASP.NET Core

## Description / Descrição

**English:**
Web application to manage contacts, developed in **ASP.NET Core Razor Pages**.

**Português:**
Aplicação web para gerenciar contatos, desenvolvida em **ASP.NET Core Razor Pages**.

### Features / Funcionalidades

* **English:**

  * List all contacts
  * Add a new contact
  * View contact details
  * Edit existing contact
  * Delete contacts (soft delete)
  * Basic authentication to restrict access to create, edit and delete

* **Português:**

  * Listar todos os contatos
  * Adicionar um novo contato
  * Visualizar detalhes de um contato
  * Editar um contato existente
  * Excluir contatos (exclusão lógica / soft delete)
  * Autenticação básica para restringir acesso à criação, edição e exclusão

---

## Requirements / Requisitos

* **English:**

  * .NET 6
  * MariaDB 10.6
  * Docker environment provided (CloudCMD and PHPMyAdmin)
  * Modern browser (Chrome, Edge, Firefox)

* **Português:**

  * .NET 6
  * MariaDB 10.6
  * Ambiente Docker fornecido (CloudCMD e PHPMyAdmin)
  * Navegador moderno (Chrome, Edge, Firefox)

---

## Installation / Deploy / Instalação

### Local / Localmente

**English:**
Clone the repository and publish in Release mode:

```bash
git clone https://github.com/Dgrace16/contactmanagement.git
cd contactmanagement
dotnet publish -c Release -o ./build
```

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "MariaDB": "Server=recruitment.alfasoft.pt,3306;DataBase=douglascenteno-dotnet;Uid=douglascenteno-dotnet;Pwd=sJHJEAtddnOnUsO;"
  },
  "Auth": {
    "StaticUser": {
      "Username": "douglascenteno-dotnet",
      "Password": "sJHJEAtddnOnUsO"
    }
  }
}
```

**Português:**
Clone o repositório e publique em modo Release:

```bash
git clone https://github.com/Dgrace16/contactmanagement.git
cd contactmanagement
dotnet publish -c Release -o ./build
```

Atualize a connection string no `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "MariaDB": "Server=recruitment.alfasoft.pt,3306;DataBase=douglascenteno-dotnet;Uid=douglascenteno-dotnet;Pwd=sJHJEAtddnOnUsO;"
  },
  "Auth": {
    "StaticUser": {
      "Username": "douglascenteno-dotnet",
      "Password": "sJHJEAtddnOnUsO"
    }
  }
}
```

---

### Server / No servidor (Docker)

**English:**

1. Access via SSH or CloudCMD
2. Backup the old build:

```bash
mkdir -p build_old
mv build/* build_old/
```

3. Copy the new build to `/home/douglascenteno-dotnet/build/`
4. Restart the application:

```bash
touch /home/douglascenteno-dotnet/build/restart
```

5. Open the application in the browser:
   [https://douglascenteno-dotnet.recruitment.alfasoft.pt](https://douglascenteno-dotnet.recruitment.alfasoft.pt)

**Português:**

1. Acesse via SSH ou CloudCMD
2. Faça backup da build antiga:

```bash
mkdir -p build_old
mv build/* build_old/
```

3. Copie a nova build para `/home/douglascenteno-dotnet/build/`
4. Reinicie a aplicação:

```bash
touch /home/douglascenteno-dotnet/build/restart
```

5. Abra a aplicação no navegador:
   [https://douglascenteno-dotnet.recruitment.alfasoft.pt](https://douglascenteno-dotnet.recruitment.alfasoft.pt)

---

## Project Structure / Estrutura do Projeto

```
ContactManagement/
│
├── Pages/
│   ├── Index.cshtml          # Contact list / Lista de contatos
│   ├── Contacts/
│   │   ├── Create.cshtml     # Add contact / Adicionar contato
│   │   ├── Edit.cshtml       # Edit contact / Editar contato
│   │   ├── Details.cshtml    # Contact details / Detalhes do contato
│   │   └── Delete.cshtml     # Soft delete / Exclusão lógica
│
├── wwwroot/                  # Static files / Arquivos estáticos (CSS, JS, imagens)
├── Data/                     # DbContext and migrations / DbContext e migrations
├── Models/                   # Contact entity / Entidade Contact
├── appsettings.json           # Database settings / Configurações do banco
└── Program.cs                # Application setup / Configuração da aplicação
```

---

## Test User / Usuário de Teste

* **Username:** `douglascenteno-dotnet`
* **Password:** `sJHJEAtddnOnUsO`

> **English:** This user can create, edit, and delete contacts
> **Português:** Este usuário pode criar, editar e excluir contatos

---

## Notes / Notas

* **English:**

  * Deletion is soft delete
  * Contact phone and email are unique
  * Validations implemented via server-side Data Annotations
  * Migrations create database tables automatically

* **Português:**

  * Exclusão é lógica (soft delete)
  * Contato (telefone) e e-mail são únicos
  * Validações implementadas via Data Annotations no servidor
  * Migrations criam automaticamente as tabelas do banco
