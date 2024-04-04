CREATE DATABASE programacao_do_zero;

USE programacao_do_zero;

CREATE TABLE usuario(

id INT NOT NULL AUTO_INCREMENT,
nome VARCHAR(50) NOT NULL ,
sobrenome VARCHAR(150) NOT NULL ,
telefone VARCHAR(15) NOT NULL,
senha VARCHAR(30) NOT NULL,
email VARCHAR(50) NOT NULL,
genero VARCHAR(20) NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE endereco(
id INT NOT NULL AUTO_INCREMENT,
cep VARCHAR(12) NOT NULL,
rua VARCHAR(250) NOT NULL,
numero VARCHAR(30) NOT NULL,
bairro VARCHAR(250) NOT NULL,
complemento VARCHAR(200) NULL,
cidade VARCHAR(250) NOT NULL,
estado VARCHAR(2) NOT NULL, 
PRIMARY KEY(id)
);

--RELACIONAR AS TABELAS DE USUARIO E ENDEREÇO
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

--INSERIR USUARIOS
INSERT INTO usuario(nome,sobrenome,telefone,senha,email,genero)VALUES
('Rafael',
'olegario',
'(16) 99134-2553',
'adm123',
'rafaelbisofficel@gmail.com',
'Masculino')

--SELECIONAR USUARIOS
SELECT* FROM usuario;

--SELECIONAR 1 USUARIO
SELECT* FROM usuarioWHERE email = 'rafaelbisofficel@gmail.com';

--ALTERNAR INFORMAÇOES USURIO
UPDATE usuario SET senha='123' WHERE id=1;

-- EXCLUIR USUARIO
DELETE FROM usuario WHERE id=x;