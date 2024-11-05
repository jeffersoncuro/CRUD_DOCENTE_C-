CREATE DATABASE DB_EF_CUROTAQUILA_JEFFERSON;
	GO

	USE DB_EF_CUROTAQUILA_JEFFERSON;
	GO


	CREATE TABLE Docentes (
		codigo INT PRIMARY KEY IDENTITY,
		nombre VARCHAR(50),
		apellido VARCHAR(50),
		profesion VARCHAR(50),
		tipodocumento VARCHAR(50),
		documento VARCHAR(20)
	);

	GO


	CREATE PROCEDURE LISTADOCENTES
	AS
	BEGIN
		SELECT * FROM Docentes;
	END;
	GO

	CREATE PROCEDURE EDITARDOCENTES
		@Id INT,
		@Nombre VARCHAR(50),
		@Apellido VARCHAR(50),
		@Profesion VARCHAR(50),
		@TipoDocumento VARCHAR(50),
		@Documento VARCHAR(20)
	AS
	BEGIN
		UPDATE Docentes
		SET Nombre = @Nombre,
			Apellido = @Apellido,
			Profesion = @Profesion,
			TipoDocumento = @TipoDocumento,
			Documento = @Documento
		WHERE codigo = @Id;
	END;
	GO


	CREATE PROCEDURE BUSCARDOCENTESPORID
		@Id INT
	AS
	BEGIN
		SELECT * FROM Docentes WHERE codigo = @Id;
	END;
	GO


	CREATE PROCEDURE REGISTRARDOCENTES
		@Nombre VARCHAR(50),
		@Apellido VARCHAR(50),
		@Profesion VARCHAR(50),
		@TipoDocumento VARCHAR(50),
		@Documento VARCHAR(20)
	AS
	BEGIN
		INSERT INTO Docentes (Nombre, Apellido, Profesion, TipoDocumento, Documento)
		VALUES (@Nombre, @Apellido, @Profesion, @TipoDocumento, @Documento);
	END;
	GO

	--eliminar
	CREATE PROCEDURE ELIMINARDOCENTESPORID
		@Id INT
	AS
	BEGIN
		DELETE FROM Docentes WHERE codigo = @Id;
	END;
	GO




	INSERT INTO Docentes (nombre, apellido, profesion, tipodocumento, documento)
	VALUES 
	('Zephyr', 'Fenwick', 'Ingenier a de Datos', 'DNI', '12345678A'),
	('Thalassa', 'Rosenquist', 'Neurociencia Computacional', 'Carnet de Identidad', 'CI-9876543'),
	('Lysander', 'Dartmouth', 'Criptograf a Avanzada', 'Pasaporte', 'AB1234567'),
	('Aurelia', 'Pendleton', 'Bioinform tica', 'C dula de Identidad', 'CI-8765432'),
	('Oberon', 'Fairchild', 'Ingenier a Biom dica', 'Documento Nacional de Identidad', 'DNI-65432187'),
	('Eowyn', 'Whitmore', 'Arquitectura de Software', 'NIE', 'X-9876543-Z'),
	('Cassiopeia', 'Thornfield', 'F sica Te rica', 'Pasaporte', 'CD9876543'),
	('Emeric', 'Hawthorne', 'Inteligencia Artificial', 'Tarjeta de Residencia', 'TR-1234567X'),
	('Bastian', 'Rutherford', 'Rob tica Avanzada', 'Documento de Identidad', 'DI-54321678'),
	('Calypso', 'Winthrop', 'Biomec nica', 'Carnet de Extranjer a', 'CE-8765432Y');