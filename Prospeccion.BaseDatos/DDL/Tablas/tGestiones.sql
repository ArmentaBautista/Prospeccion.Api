
create table  tGestiones(
	Id int primary key,
	IdGestor SMALLINT
		constraint FK_tGestiones_IdGestor
			references tGestores(Id),
	IdPersona int
		constraint FK_tGestiones_IdPersona
			references tPersonas(id),
	IdActividad tinyint
		constraint FK_tGestiones_IdActividad
			references tActividades([Id]),
	IdResultado tinyint
		constraint FK_tGestiones_IdResultado
			references tResultados(Id),
	Fecha date default getdate() NOT NULL,
	Hora time default getdate() NOT NULL,
	Estatus tinyint default 1
)
GO



