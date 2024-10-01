
create table tPersonas(
	Id int primary key identity,
	Nombre varchar(64),
	ApellidoPaterno varchar(32),
	ApellidoMaterno varchar(32),
	FechaNacimiento date,
	NombreCompleto as concat_ws(' ',Nombre,ApellidoPaterno,ApellidoMaterno),
	Domicilio varchar(256) default '',
	Telefono char(10) default '',
	Fecha date default getdate() NOT NULL,
	Hora time default getdate() NOT NULL,
	Estatus tinyint default 1
)
GO




