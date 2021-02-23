CREATE TABLE Usuario (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NomeCompleto varchar(255) NOT NULL,
    Email varchar(255) NOT NULL,
    Senha varchar(255) NOT NULL
);

CREATE TABLE CategoriaProduto (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Descricao varchar(255) NOT NULL,
);

CREATE TABLE Produto (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IdCategoriaProduto int  NOT NULL,
    Descricao varchar(255) NOT NULL,
	Preco decimal(15,2) NOT NULL
);

ALTER TABLE Produto
ADD FOREIGN KEY (IdCategoriaProduto) REFERENCES CategoriaProduto(Id);

--Carga base

insert into Usuario (NomeCompleto,Email, Senha) values ('Vinícius Luiz Lopes','viniciuslopesti@gmail.com','12345')

insert into CategoriaProduto (Descricao) values ('Alimento')
insert into CategoriaProduto (Descricao) values ('Bebida')
insert into CategoriaProduto (Descricao) values ('Outros')