﻿# CRUDDapperRepositoryPattern

## 참고
[C# Tutorial Insert Update Delete View data from database using Dapper CRUD ADO NET FoxLearn](https://youtu.be/pn8wrK3FyGA?si=WnoAhCHZ5CCy_ggz)
[Mastering Dapper with the Generic Repository Pattern](https://medium.com/@ZuraizAhmedShehzad/mastering-the-dapper-orm-with-the-generic-repository-pattern-8049eb9de43b)

## About
* C#, WinForm, MSSQL 2022, DevExpress(Report), Dapper, Repository Pattern(테이블 클래스, DataGridView 데이터 원본을 클래스로 선택), Stored Procedure
* C# Mini Project CRUD Insert Update Delete and View Student Profile data from SQL database 
* using ADO.NET Dapper ORM, Stored Procedure, Repository Pattern in C# step by step

## Environment
* IDE: Visual Studio 2022
* Language: C#
* Applied Project Template: .NET 8.0
* NuGet  
    * Dapper
    * System.Data.SqlClient
* Third Party Libraries    
* DataBase: MS SQL 2022

## 작업
* Student.cs: class는 반드시 public로 선언해야 DataGridView에 데이터 원본 선택시 나타난다.(studentBindingSource가 생성됨)
* DataGridView에서 데이터 원본 선택 -> 데이터 원본 형식이름 Student를 선택하면 DataGridView의 컬럼이 나타난다.
* txtStudentID, txtFullName, txtBirthday, txtEmail, txtAddress의 컨트롤의 속성 
* -> DataBindings-> Text를 studentBindingSource의 각 컬럼명을 선택한다.
* chkGender 컨트롤의 속성 -> DataBindings-> Checked를 studentBindingSource의 Gender컬럼으로 선택한다.
* IGenericRepository<T>를 상속해서 각 Repository 클래스를 구현할 경우 매개변수명칭은 클래스에 맞게 수정해서 사용한다.
* ex) public bool Add(Student entity) => public bool Add(Student student)
