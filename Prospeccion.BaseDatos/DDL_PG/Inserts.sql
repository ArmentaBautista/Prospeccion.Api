insert into puesto (nombre, descripcion)
values 
	('Gestor', 'Agente de ventas y cobranza'),
	('Administrador', 'Administrador de ventas');



insert into Colaborador (nombre, apellidos, CorreoElectronico, idpuesto)
values 
	('Ivan','Meza','carlos.armenta@intelix.mx', 2),
	('Alicia','Ambrosio','carlos.armenta@intelix.mx', 1);


	
insert into ColaboradorUsuario (IdColaborador, usuario, clave)
values
	(1, 'imm','123456'),
	(2, 'azz','123456');
	

insert into permiso(nombre, descripcion)
values
	('Actividades', 'Acciones de Venta'),
	('Resultados', 'Posibles Resultados'),
	('Personas', 'Directorio'),
	('Gestores', 'Personal Ventas'),
	('Gestiones', 'Esfuerzo de ventas');
	


insert into ColaboradorUsuarioPermiso (IdColaboradorUsuario, IdPermiso)
values
	(1, 1),
	(1, 2),
	(1, 3),
	(1, 4),
	(2, 3),
	(2, 5);

