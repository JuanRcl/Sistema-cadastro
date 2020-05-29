create database cadastro;
use cadastro;
drop database cadastro;
create table dados_pessoais(
	nome 	varchar(50) not null,
    email	varchar(20) not null,
    cpf		varchar(11) not null,
    estado	varchar(2),
    primary key(cpf)
);
insert into dados_pessoais values(
	"Joao",
    "juan@gmail.com",
    "12345678977",
    "SP"
);
describe dados_pessoais;
drop table dados_pessoais;
select * from dados_pessoais;
alter table dados_pessoais change column email email varchar(35);
delete from dados_pessoais where cpf = "00012345688";

