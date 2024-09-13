# 🎉 HepsiBurada API 🚀

Welcome to the **HepsiBurada API** documentation! This API powers various features for user authentication, product and brand management, using a robust architecture and modern technologies. Let's dive into the details! 🔍

## Table of Contents
- [Overview](#overview)
- [Authentication Endpoints](#authentication-endpoints-🔐)
- [Brand Endpoints](#brand-endpoints-🏷️)
- [Product Endpoints](#product-endpoints-🛒)
- [Technologies Used](#technologies-used-⚙️)
- [Security](#security-🛡️)

## Overview
This API provides a powerful and scalable platform for managing users, brands, and products in the HepsiBurada ecosystem. It uses **CQRS**, **Onion Architecture**, and **JWT Authentication** to ensure clean, maintainable, and secure code. 🎯

- **Version:** v1
- **Base URL:** `/api`
- **Architecture:** Onion Architecture 🧅

## Authentication Endpoints 🔐

Here are the endpoints for handling user authentication and token management.

### Register
- **POST** `/api/Register`
- Registers a new user into the system.
- **Request Body:** `RegisterCommandRequest`
- **Response:** 
  - `200`: OK

### Login
- **POST** `/api/Login`
- Authenticates a user and returns a JWT token.
- **Request Body:** `LoginCommandRequest`
- **Response:** 
  - `200`: OK
  - 🔑 **JWT Token** is provided in the response for secure API access.

### Refresh Token
- **POST** `/api/RefreshToken`
- Refreshes the JWT token using a valid refresh token.
- **Request Body:** `RefreshTokenCommandRequest`
- **Response:** 
  - `200`: OK

### Logout
- **POST** `/api/Logout`
- Logs out the user by invalidating the tokens.
- **Response:** 
  - `200`: OK

## Brand Endpoints 🏷️

Manage brands efficiently with caching and performance improvements!

### Create Brand
- **POST** `/api/Brand`
- Adds **1 million random brands** using the `Faker` library for testing large datasets! 📊
- **Request Body:** `CreateBrandsCommandRequest`
- **Response:** 
  - `200`: OK
  - Uses **Unit of Work** to handle transaction management. 💼

### Get Brands
- **GET** `/api/Brand`
- Fetches brands with **Redis caching** for faster retrieval. ⚡
- **Response:** 
  - `200`: OK

## Product Endpoints 🛒

Operations related to product management, fully integrated with CQRS.

### Create Product
- **POST** `/api/Product`
- Adds a new product.
- **Request Body:** `CreateProductCommandRequest`
- **Response:** 
  - `200`: OK

### Update Product
- **PUT** `/api/Product`
- Updates an existing product.
- **Request Body:** `UpdateProductCommandRequest`
- **Response:** 
  - `200`: OK

### Delete Product
- **DELETE** `/api/Product`
- Deletes a product by its ID.
- **Parameters:** 
  - `Id`: `int32`
- **Response:** 
  - `200`: OK

### Get Products
- **GET** `/api/Product`
- Retrieves all products.
- **Response:** 
  - `200`: OK

## Technologies Used ⚙️

Here are the cutting-edge technologies that power this API:

- **JWT Authentication** for secure access 🔐
- **CQRS** (Command Query Responsibility Segregation) for clear separation of read and write logic ✂️
- **Onion Architecture** for a well-organized and maintainable code structure 🧅
- **Unit of Work** to handle transactions and maintain consistency 💼
- **Redis** for caching frequently requested data ⚡
- **Faker** to generate a large dataset of random brands 📊
- **MediatR** for handling commands and queries in a decoupled way 🎯
- **AutoMapper** for mapping between data models 🔄
- **FluentValidation** for clean and robust request validation ✅

## Security 🛡️

This API uses **JWT Bearer** tokens for authentication. To access secure endpoints, include the `Authorization` header Your JWT Token

