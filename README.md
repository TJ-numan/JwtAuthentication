JWT Authentication System using ASP.NET Core 8

 Overview

This project — **JwtAuthentication** — is a backend API developed using **ASP.NET Core 8**, designed to demonstrate a **modern, secure, and modular JWT (JSON Web Token) authentication and authorization system**. It serves as a complete example of how to implement token-based security in RESTful APIs using industry-standard techniques while maintaining a clean, scalable architecture.

The primary goal of this project is to showcase the implementation of a **stateless authentication system** using **JWT tokens**, which are widely used in distributed web systems, mobile applications, and microservices. The system allows user authentication, token generation, and secured API access through bearer tokens, demonstrating best practices in security and ASP.NET Core middleware configuration.

Although this project does not use a database for simplicity, all the logic for user validation, token creation, and claims management has been **hand-coded** to clearly illustrate the underlying concepts. The API comes equipped with **Swagger UI**, offering a user-friendly interface for testing and exploring endpoints, making it a perfect educational and reference project for developers learning secure API development in ASP.NET Core.

---

 Key Objectives

* To demonstrate **JWT-based authentication and authorization** in ASP.NET Core 8.
* To show how to configure **authentication middleware** and protect API routes with policies and attributes.
* To explain how to structure a secure and modular **REST API** in .NET.
* To provide a reference implementation that can easily be extended to include real databases and user management.
* To utilize **Swagger UI** as a built-in interface for API documentation and testing.

---

 Conceptual Background

In modern web development, traditional cookie-based authentication often poses scalability challenges, especially for APIs serving multiple platforms (web, mobile, IoT). **JWT (JSON Web Token)** provides a stateless solution, enabling the backend to issue signed tokens after successful login. The client then attaches this token to every subsequent request for validation.

JWT tokens are self-contained — they include encoded user identity and claims information, which the server verifies using a secret key. This removes the need for session storage and allows seamless scaling of services.

In this project, the **JWT token generation and validation pipeline** has been implemented from scratch using **Microsoft’s built-in authentication middleware**, providing a detailed, practical understanding of token-based security in ASP.NET Core.

---

 Architecture and Design

The project follows a **modular and layered structure**, even though it is simple and database-free. It simulates how a professional backend service would be structured in a real-world scenario.

**Main Layers and Components:**

1. **Controllers Layer:** Handles HTTP requests and routes them to the appropriate logic.
2. **Models Layer:** Defines the data models such as user credentials and authentication responses.
3. **Services Layer:** Encapsulates business logic related to authentication and token generation.
4. **Helpers/Utilities:** Handles configuration, key management, and JWT token creation.
5. **Startup / Program.cs:** Configures middleware, services, and authentication schemes.

The architecture emphasizes **separation of concerns**, ensuring that each layer is responsible for a specific function. This design can easily be extended to connect with a database or external services.

---

 Technology Stack

| Category                | Technology                 |
| ----------------------- | -------------------------- |
| Framework               | ASP.NET Core 8             |
| Language                | C#                         |
| Authentication          | JSON Web Token (JWT)       |
| API Documentation       | Swagger / OpenAPI          |
| Token Signing           | HMAC-SHA256                |
| Development Environment | Visual Studio 2022         |
| Hosting Type            | Self-hosted / Kestrel      |
| Design Pattern          | MVC / Layered Architecture |

---

 Features

#### 1. **User Authentication**

Users can authenticate using predefined credentials. On successful login, the API issues a signed JWT token that contains essential user claims and an expiration period.

#### 2. **JWT Token Generation**

The system generates secure, time-bound tokens using symmetric encryption (HMAC-SHA256). Tokens include payload information such as username, role, and issued timestamps.

#### 3. **Authorization Middleware**

Once authenticated, clients can access secured endpoints only if a valid token is present in the request header. The middleware validates and decodes the JWT before allowing further access.

#### 4. **Role-based Access Control (RBAC)**

Although simplified, the system demonstrates how role-based security can be integrated using **claims**. This helps differentiate between user roles like “Admin” and “User.”

#### 5. **Swagger UI Integration**

Built-in **Swagger UI** offers a convenient interface for visualizing, testing, and debugging API endpoints. It supports token input for testing protected routes.

#### 6. **Exception Handling and Logging**

The API is designed with clean error responses and structured exception handling, making it more production-ready and easier to maintain.

#### 7. **Stateless Architecture**

All authentication data is stored in tokens, not on the server, achieving a **fully stateless design** that scales efficiently across distributed systems.

---

 Core Implementation Details

**1. Token Configuration:**
The `appsettings.json` file contains the secret key and token lifetime configuration. The system uses this key to sign and validate tokens, ensuring data integrity and preventing tampering.

**2. Token Creation Logic:**
Token generation is implemented using the `JwtSecurityTokenHandler` class, which builds the token with claims and encodes it using the secret key.

**3. Middleware Setup:**
Authentication and authorization middleware are configured in the `Program.cs` file, using:

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere")),
            ClockSkew = TimeSpan.Zero
        };
    });
```

**4. Token Validation:**
The API verifies the token’s integrity for every request on protected endpoints, ensuring that only authorized users can access secured data.

**5. Hand-coded User Data:**
For demonstration, user credentials and roles are defined directly in the code. This avoids database complexity while focusing entirely on authentication mechanics.

---

 API Endpoints

| Endpoint           | Method | Description                                 | Authentication      |
| ------------------ | ------ | ------------------------------------------- | ------------------- |
| `/api/auth/login`  | POST   | Authenticates a user and issues a JWT token | Public              |
| `/api/auth/secure` | GET    | Returns data for authenticated users        | Requires JWT        |
| `/api/auth/admin`  | GET    | Example of role-based access                | Requires Admin role |

Each endpoint is tested and documented through Swagger, allowing users to quickly try the authentication flow interactively.

---

 How It Works

1. **Login Phase:**

   * A user sends their username and password to the `/api/auth/login` endpoint.
   * The system verifies credentials against hardcoded data.
   * If valid, the system generates a JWT token signed with a secret key and returns it.

2. **Token Usage:**

   * The client includes the JWT in the `Authorization` header for all protected endpoints.
   * Example: `Authorization: Bearer <your-token>`

3. **Accessing Protected Data:**

   * The middleware verifies the token.
   * If valid and not expired, access is granted to the secured endpoint.
   * Otherwise, a 401 (Unauthorized) response is returned.

This flow mirrors how authentication works in production-grade systems, minus the database dependency.

---

 Development Process

The project was built in **Visual Studio 2022** using the latest **.NET SDK 8**.
The key steps included:

1. Creating an ASP.NET Core Web API project.
2. Configuring JWT authentication middleware.
3. Designing the user models and authentication controller.
4. Implementing token generation logic.
5. Integrating Swagger for testing.
6. Testing endpoints through Swagger and Postman.

The result is a lightweight, well-documented, and scalable authentication service suitable for integration into any modern web or mobile application.

---

 Security Best Practices Demonstrated

* Use of **Symmetric Key Encryption** with `HMAC-SHA256`.
* Proper **token expiration** and **validation** to prevent replay attacks.
* Enforcement of **Bearer Token Authentication** header.
* Implementation of **Role-based access** for fine-grained authorization.
* Middleware-level security enforcement using `[Authorize]` attributes.

---

 Challenges & Learnings

Building this system provided a strong understanding of:

* The **internal structure of JWT tokens** — header, payload, and signature.
* How **ASP.NET Core middleware** handles authentication pipelines.
* Implementing **custom claim-based logic**.
* The importance of **statelessness** for scalable APIs.
* Testing APIs efficiently using **Swagger and Postman**.

It also reinforced key software engineering principles such as modular design, separation of concerns, and dependency injection.

---

 Future Enhancements

While this version focuses on core JWT concepts, future improvements could include:

* Integration with a **SQL Server or MySQL database** for dynamic user management.
* Refresh token implementation for extended sessions.
* Password hashing and encryption using **ASP.NET Core Identity**.
* Role management via database-driven claims.
* Deployment to **Azure App Service** or **Docker** for scalability.
* Integration testing and CI/CD pipelines using **GitHub Actions**.

---

 Use Case Scenarios

This project can be extended or referenced in:

* Any backend service requiring secure token-based authentication.
* Enterprise-level REST APIs needing OAuth2 or OpenID Connect integration.
* Mobile or SPA (React, Angular, Flutter) applications consuming protected endpoints.
* Educational material for learning JWT in ASP.NET Core 8.

---

 Repository

🔗 **GitHub Repository:** [https://github.com/TJ-numan/JwtAuthentication](https://github.com/TJ-numan/JwtAuthentication)

The repository includes:

* Complete source code
* Detailed comments
* Swagger UI configuration
* Example tokens and usage instructions


---

Would you like me to also create a **shorter (150–200 word summary version** for your LinkedIn “Featured” section or post caption) to accompany this long description? It helps attract attention while linking to your GitHub repo.
