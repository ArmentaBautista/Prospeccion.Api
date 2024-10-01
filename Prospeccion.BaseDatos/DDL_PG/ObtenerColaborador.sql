CREATE OR REPLACE FUNCTION ObtenerColaboradoresPorUsuario(p_usuario VARCHAR)
RETURNS TABLE (
    Nombre VARCHAR(50),
    Apellidos VARCHAR(50),
    CorreoElectronico VARCHAR(100),
    Puesto VARCHAR(50),
    Estado BOOLEAN
) AS $$
BEGIN
    RETURN QUERY
    SELECT 
        c.Nombre,
        c.Apellidos,
        c.CorreoElectronico,
        p.Nombre AS Puesto,
        c.Estado
    FROM 
        Colaborador c
    inner join 
    	colaboradorusuario cu on c.id = cu.idcolaborador 
    INNER JOIN 
        Puesto p ON c.IdPuesto = p.Id
    WHERE 
        cu.usuario = p_usuario;
END;
$$ LANGUAGE plpgsql;