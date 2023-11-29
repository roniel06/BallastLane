# BallastLane

### User Story
As a user or BallastLane Api i want to be able to create users, a user shoul have a Name, LastName, Date of Birth,
Phone Number and Address. That created user i should be able to use it in order to create Notes so every note belongs to a user.
The note should have Title, Text, Date.

I should have Endpoints to Create, Update, Obtain, Delete users and Notes.

## Technologies Used
[![License: GNU](https://img.shields.io/badge/License-GNU%20GPL-blue)](https://www.gnu.org/licenses/gpl-3.0) ![](https://img.shields.io/badge/.NET_Core-blue?logo=.net) ![](https://img.shields.io/badge/Entity_Framework_Core-purple?logo=.net) ![](https://img.shields.io/badge/xUnit-orange?logo=xunit) ![](https://img.shields.io/badge/-ReactJs-61DAFB?logo=react)
- .NET 8 - A free, cross-platform, open-source framework for building modern cloud-based and internet-connected applications.
- Entity Framework Core - A modern object-database mapper for .NET that provides a clean and elegant way to access relational databases.
- xUnit - A free, open-source, and community-focused unit testing tool for the .NET Framework.
- AutoFixture - AutoFixture makes it easier for developers to do Test-Driven Development by automating non-relevant Test Fixture Setup, allowing the Test Developer to focus on the essentials of each test case.

# Getting Started

## Prerequisites
- .NET Core SDK version 8.
- Node.js version 18.0 or later.

## Installation

1. Clone the repository:
```bash
git clone https://github.com/roniel06/BallastLane.git
```

2. Change into the project directory:
```bash
cd BallastLane
```

3. Restore the .NET Core packages:
```bash
dotnet restore
```

4. Restore the Node.js packages:
```bash
cd BallastLane.Client
npm install
```

## Usage

1. Run the backend project:
```bash
cd BallastLane.Api
```

```
dotnet run
```

Make sure to take the port provided by the host

2. Run the frontend project:
```bash
cd BallastLane.Client
```

go to ```BallastLane.Client\src\httpServices\httpService.js ```
and change the port of baseUrl to the one provided by the backend project.

Now Execute
```
npm run dev
```
