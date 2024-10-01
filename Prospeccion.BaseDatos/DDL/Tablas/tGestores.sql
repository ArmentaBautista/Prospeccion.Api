

CREATE table tGestores(
	Id SMALLINT primary key identity,
	IdPersona int
		constraint FK_tGestoress_IdPersona
			references tPersonas(id),
	Usuario varchar(16) not null,
	Fecha date default getdate() NOT NULL,
	Hora time default getdate() NOT NULL,
	Estatus tinyint default 1
)
GO
