

create table tActividades(
	[Id] int primary key identity,
	Actividad varchar(24) not null,
	Fecha date default getdate() NOT NULL,
	Hora time default getdate() NOT NULL,
	Estatus int default 1 NOT NULL
)
GO
