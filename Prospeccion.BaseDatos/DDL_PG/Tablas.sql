CREATE TABLE Puesto (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50),
    Descripcion VARCHAR(150),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaCreacion TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioCreacion VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50)
);

CREATE TABLE Colaborador (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    CorreoElectronico VARCHAR(100),
    IdPuesto INT NOT NULL,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaCreacion TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioCreacion VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_Colaborador_Puesto FOREIGN KEY (IdPuesto) REFERENCES Puesto(Id)
);

CREATE TABLE ColaboradorUsuario (
    Id SERIAL PRIMARY KEY,
    IdColaborador INT NOT NULL,
    Usuario VARCHAR(50),
    Clave VARCHAR(50),
    BloqueadoHasta TIMESTAMP,
    UltimoBloqueo TIMESTAMP,
    IntentosFallidos INT,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaCreacion TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioCreacion VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_ColaboradorUsuario_Colaborador FOREIGN KEY (IdColaborador) REFERENCES Colaborador(Id)
);

CREATE TABLE Permiso (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(50),
    Descripcion VARCHAR(150),
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaCreacion TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioCreacion VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50)
);

CREATE TABLE ColaboradorUsuarioPermiso (
    Id SERIAL PRIMARY KEY,
    IdColaboradorUsuario INT NOT NULL,
    IdPermiso INT NOT NULL,
    Estado BOOLEAN NOT NULL DEFAULT TRUE,
    FechaCreacion TIMESTAMP NOT NULL DEFAULT NOW(),
    UsuarioCreacion VARCHAR(50) NOT NULL DEFAULT 'consola',
    FechaModificacion TIMESTAMP,
    UsuarioModificacion VARCHAR(50),
    CONSTRAINT FK_ColaboradorUsuarioPermiso_ColaboradorUsuario FOREIGN KEY (IdColaboradorUsuario) REFERENCES ColaboradorUsuario(Id),
    CONSTRAINT FK_ColaboradorUsuarioPermiso_Permiso FOREIGN KEY (IdPermiso) REFERENCES Permiso(Id)
);
