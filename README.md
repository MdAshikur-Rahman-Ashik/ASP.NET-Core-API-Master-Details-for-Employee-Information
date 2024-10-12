<h1>👨‍💼 ASP.NET Core API Master-Details for Employee Information</h1>

<p>This project is an ASP.NET Core Web API that implements a master-detail relationship for managing employee information using the Entity Framework Code First approach. It allows you to manage employees, their Experience, and related tasks, offering CRUD operations for each entity.</p>

<h2>📑 Table of Contents</h2>
<ul>
  <li><a href="#features">Features</a></li>
  <li><a href="#technologies">Technologies</a></li>
  <li><a href="#getting-started">Getting Started</a></li>
  <li><a href="#usage">Usage</a></li>
  <li><a href="#testing">Testing</a></li>
  <li><a href="#contributing">Contributing</a></li>
  <li><a href="#license">License</a></li>
  <li><a href="#contact">Contact</a></li>
</ul>

<h2 id="features">🚀 Features</h2>
<ul>
  <li>Manage employee information with associated departments and tasks.</li>
  <li>Master-detail CRUD operations for Employees, Experience, and Tasks.</li>
  <li>RESTful Web API using ASP.NET Core.</li>
  <li>Authentication for secured access (optional).</li>
</ul>

<h2 id="technologies">🛠️ Technologies</h2>
<ul>
  <li><strong>Backend:</strong> ASP.NET Core Web API</li>
  <li><strong>ORM:</strong> Entity Framework Core (Code First)</li>
  <li><strong>Database:</strong> SQL Server</li>
  <li><strong>Testing:</strong> Postman</li>
</ul>

<h2 id="getting-started">⚙️ Getting Started</h2>
<h3>🔧 Prerequisites</h3>
<p>Ensure you have the following installed:</p>
<ul>
  <li><a href="https://visualstudio.microsoft.com/" target="_blank">Visual Studio</a> (v2019 or later)</li>
  <li><a href="https://dotnet.microsoft.com/download" target="_blank">.NET 6.0 SDK</a></li>
  <li><a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads" target="_blank">SQL Server</a></li>
</ul>

<h3>🔧 Required NuGet Packages</h3>
<p>Make sure to install the following NuGet packages:</p>
<ul>
  <li><code>Microsoft.AspNetCore.Authentication.JwtBearer</code> </li>
  <li><code>Microsoft.EntityFrameworkCore</code> </li>
  <li><code>Microsoft.EntityFrameworkCore.SqlServer</code></li>
  <li><code>Microsoft.EntityFrameworkCore.Tools</code> </li>
  <li><code>Newtonsoft.Json</code> </li>
</ul>

<h3>🔧 Steps to Run</h3>
<ol>
  <li>Clone the repository by running the following command in your terminal:</li>
  <pre><code>https://github.com/MdAshikur-Rahman-Ashik/ASP.NET-Core-API-Master-Details-for-Employee-Information</code></pre>
  <li>Set up the connection string in the <code>appsettings.json</code> file to connect to your SQL Server instance.</li>
  <li>Run Entity Framework Core migrations to create the database schema:</li>
  <ul>
    <li>Open the <strong>Package Manager Console</strong> in Visual Studio.</li>
    <li>Run the following commands:</li>
    <pre><code>
    Add-Migration InitialCreate
    Update-Database
    </code></pre>
  </ul>
  <li>Build and run the project in Visual Studio.</li>
</ol>

<h2 id="usage">💻 Usage</h2>
<ul>
  <li>Manage employees by adding, editing, deleting, or viewing employee details.</li>
  <li>Assign employees to departments and link tasks to each employee.</li>
</ul>

<h3>📬 Testing with Postman</h3>
<p>You can use <a href="https://www.postman.com/" target="_blank">Postman</a> to test the Web API. Follow these steps:</p>

<h4>1. Base URL</h4>
<p>Make sure to use the correct base URL for the API:</p>
<pre><code>https://localhost:{port}/api/</code></pre>

<h4>2. Testing GET Requests</h4>
<p>To retrieve employee details:</p>
<pre><code>GET https://localhost:{port}/api/employees</code></pre>

<h4>3. Testing POST Requests</h4>
<p>To add a new employee, use the following URL and JSON body:</p>
<pre><code>POST http://localhost:{port}/api/employees</code></pre>
<p>JSON Body Example:</p>
<pre><code>{
  "EmployeeName": "Ashik",
  "IsActive": false,
  "JoinDate": "2024-05-06",
  "ImageName": "AshikPhoto",
  "ImgFile": "Select Image",
  "Experiences": [
    {
      "Title": "CR",
      "Duration": 5
    },
    {
      "Title": "CM",
      "Duration": 6
    }
  ]
}
</code></pre>

<h4>4. Testing PUT Requests</h4>
<p>To update an existing employee, use the following URL and JSON body:</p>
<pre><code>PUT http://localhost:{port}/api/employees/1</code></pre>
<p>JSON Body Example:</p>
<pre><code>{
  "EmployeeName": "Rayhan",
  "IsActive": true,
  "JoinDate": "2024-05-06",
  "ImageName": "RayhanPhoto",
  "ImgFile": "Select Image",
  "Experiences": [
    {
      "Title": "SEO",
      "Duration": 5
    },
    {
      "Title": "CM",
      "Duration": 5
    }
  ]
}
</code></pre>

<h4>5. Testing DELETE Requests</h4>
<p>To delete an employee:</p>
<pre><code>DELETE https://localhost:{port}/api/employees/{id}</code></pre>

<h4>6. Authentication</h4>
<p>If authentication is required, include authentication tokens in the headers.</p>

<h2 id="contributing">🤝 Contributing</h2>
<p>If you'd like to contribute, feel free to open a pull request or issue on the repository.</p>

<h2 id="license">📝 License</h2>
<p>This project is licensed under the MIT License.</p>

<h2 id="contact">📞 Contact</h2>
<p>For any inquiries or questions, feel free to reach out:</p>
<ul>
  <li><strong>Name:</strong> Md. Ashikur Rahman Ashik</li>
  <li><strong>Email:</strong> <a href="mailto:mohammadashikidb@gmail.com">mohammadashikidb@gmail.com</a></li>
  <li><strong>GitHub:</strong> <a href="https://github.com/MdAshikur-Rahman-Ashik" target="_blank">MdAshikur-Rahman-Ashik</a></li>
  <li><strong>LinkedIn:</strong> <a href="https://www.linkedin.com/in/md-ashikur-rahman-ashik-560b00185" target="_blank">Md. Ashikur Rahman Ashik</a></li>
</ul>

![coreapi1](https://github.com/user-attachments/assets/2c46aa79-26e9-4124-b158-363dd7e7a52d)
![coreapi2](https://github.com/user-attachments/assets/2b011d79-67a4-4340-b439-b6d092c9fead)
![coreapi3](https://github.com/user-attachments/assets/cd91eed0-949d-4f37-b062-be88dd7f7f8e)
![coreapi4](https://github.com/user-attachments/assets/a488c1db-fefe-40d2-9e75-6e1dc93de3a4)
![coreapi-5](https://github.com/user-attachments/assets/2392e6ba-033e-415c-8982-fc7153003a91)
![coreapi-6](https://github.com/user-attachments/assets/383e0612-480b-4684-93c3-c05ab449fe9c)

