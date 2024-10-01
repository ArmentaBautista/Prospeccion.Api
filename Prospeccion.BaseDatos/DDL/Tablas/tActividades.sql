

create table tActividades(
	[Id] tinyint primary key identity,
	Actividad varchar(24) not null,
	Fecha date default getdate() NOT NULL,
	Hora time default getdate() NOT NULL,
	Estatus tinyint default 1 NOT NULL
)
GO
