# 🎉 HepsiBurada API 🚀

Welcome to the **HepsiBurada API** documentation! This API supports features like user authentication, product and brand management, built on a robust architecture. Let's dive into the details! 🔍

## Table of Contents
- [Overview](#overview)
- [Authentication Endpoints](#authentication-endpoints-🔐)
- [Brand Endpoints](#brand-endpoints-🏷️)
- [Product Endpoints](#product-endpoints-🛒)
- [Technologies Used](#technologies-used-⚙️)
- [Security](#security-🛡️)

## Overview
This API provides a scalable platform for managing users, brands, and products within the HepsiBurada ecosystem. Built with modern technologies such as **CQRS**, **Onion Architecture**, and **JWT Authentication**, the API ensures clean, maintainable, and secure code. 🎯

- **Architecture:** Onion Architecture 🧅
- **Database:** PostgreSQL 🐘
- **Containerization:** Docker 🐳
- **Unit of Work** is utilized in all operations to ensure transaction consistency. 💼

## Authentication Endpoints 🔐

Endpoints for user authentication and token management are listed below.

### Register
- **POST** `/api/Register`
- Registers a new user.

### Login
- **POST** `/api/Login`
- Authenticates the user and returns a JWT token. 
  - 🔑 **JWT Token** is provided for secure API access.

### Refresh Token
- **POST** `/api/RefreshToken`
- Refreshes the JWT token using a valid refresh token.

### Logout
- **POST** `/api/Logout`
- Invalidates the user's tokens and logs them out.

## Brand Endpoints 🏷️

Efficiently manage brands with caching and performance enhancements!

### Create Brand
- **POST** `/api/Brand`
- Uses **Faker** library to add **1 million random brands**! 📊

### Get Brands
- **GET** `/api/Brand`
- Retrieves brands using **Redis** caching for faster access. ⚡

## Product Endpoints 🛒

### Create Product
- **POST** `/api/Product`
- Adds a new product.

### Update Product
- **PUT** `/api/Product`
- Updates an existing product.

### Delete Product
- **DELETE** `/api/Product`
- Deletes a product by its ID.

### Get Products
- **GET** `/api/Product`
- Retrieves all products.

## Technologies Used ⚙️

Key modern technologies powering this API:

- **JWT Authentication** ensures secure access 🔐
- **CQRS** (Command Query Responsibility Segregation) separates reading and writing logic ✂️
- **Onion Architecture** promotes clean, maintainable, and scalable code 🧅
- **Unit of Work** is used across all operations for transaction management 💼
- **Redis** caches frequently requested data for faster retrieval ⚡
- **Faker** generates large datasets for random brand creation 📊
- **MediatR** handles commands and queries independently 🎯
- **AutoMapper** simplifies object mapping between layers 🔄
- **FluentValidation** ensures clean and robust request validation ✅
- **PostgreSQL** powers the database 🐘
- **Docker** is used for containerization 🐳

## Security 🛡️

This API uses **JWT Bearer** tokens for authentication. To access secure endpoints, include your JWT token in the `Authorization` header
