
create table tResultados(
	Id tinyint primary key identity,
	Resultado varchar(24) not null,
	Fecha date default getdate() NOT NULL,
	Hora time default getdate() NOT NULL,
	Estatus tinyint default 1
)
GO
