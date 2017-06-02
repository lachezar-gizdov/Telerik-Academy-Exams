--Task 1
USE SuperheroesUniverse
SELECT s.Id, s.Name
FROM Superheroes s
    JOIN PlanetSuperheroes ps
    ON ps.Superhero_Id = s.Id
    JOIN Planets p
    ON ps.Planet_Id = p.Id
WHERE p.Name = 'Earth'

--Task 2
USE SuperheroesUniverse
SELECT s.Name AS [Superhero], p.Name + ' (' + pt.Name + ')' AS [Power]
FROM Superheroes s
    JOIN PowerSuperheroes ps
    ON s.Id = ps.Superhero_Id
    JOIN Powers p
    ON ps.Power_Id = p.Id
    JOIN PowerTypes pt
    ON p.PowerTypeId = pt.Id

--Task 3
USE SuperheroesUniverse
SELECT TOP 5
    p.Name AS [Planet], COUNT(*) AS [Protectors]
FROM Superheroes s
    JOIN PlanetSuperheroes ps
    ON ps.Superhero_Id = s.Id
    JOIN Planets p
    ON ps.Planet_Id = p.Id
    JOIN Alignments a
    ON s.Alignment_Id = a.Id
WHERE a.Name = 'Good'
GROUP BY p.Name
ORDER BY Protectors DESC, p.Name

--Task 4
CREATE PROCEDURE usp_UpdateSuperheroBio
    @newBio NVARCHAR(50),
    @superHeroId INT
AS
BEGIN
    UPDATE Superheroes
	SET Bio = @newBio
	WHERE Id = @superHeroId
END

EXECUTE usp_UpdateSuperheroBio @newBio = N'New Iron Man Bio' ,@superHeroId = 1

--Task 5
CREATE PROCEDURE usp_GetSuperheroInfo
    @superHeroId INT
AS
BEGIN
    SELECT heroes.Id, heroes.Name, heroes.SecretIdentity AS [Secret Identity],
        heroes.Bio, a.Name AS [Alignment], planets.Name AS [Planet], powers.Name AS [Power]
    FROM Superheroes heroes
        JOIN PowerSuperheroes ps ON heroes.Id = ps.Superhero_Id
        JOIN Powers powers ON ps.Power_Id = powers.Id
        JOIN Alignments a ON heroes.Alignment_Id = a.Id
        JOIN PlanetSuperheroes ps1 ON heroes.Id = ps1.Superhero_Id
        JOIN Planets planets ON ps1.Planet_Id = planets.Id
    WHERE heroes.Id = @superHeroId
END

EXECUTE usp_GetSuperheroInfo @superHeroId = 6

--Task 6
CREATE PROCEDURE usp_GetPlanetsWithHeroesCount

AS
BEGIN
    SELECT p.Name AS [Planet],
        SUM(CASE WHEN a.Name = 'Good' THEN 1 ELSE 0 END) [Good heroes],
        SUM(CASE WHEN a.Name = 'Neutral' THEN 1 ELSE 0 END) [Neutral heroes],
        SUM(CASE WHEN a.Name = 'Evil' THEN 1 ELSE 0 END) [Evil heroes]
    FROM Superheroes s
        JOIN PlanetSuperheroes ps ON ps.Superhero_Id = s.Id
        JOIN Planets p ON ps.Planet_Id = p.Id
        JOIN Alignments a ON s.Alignment_Id = a.Id
    GROUP BY p.Name
END

EXECUTE usp_GetPlanetsWithHeroesCount

--Task 7


--Task 8
CREATE PROCEDURE usp_PowersUsageByAlignment
AS
BEGIN
    SELECT a.Name AS [Aligment], COUNT(*) AS [Powers Count]
    FROM Superheroes s
        JOIN PowerSuperheroes ps ON s.Id = ps.Superhero_Id
        JOIN Alignments a ON s.Alignment_Id = a.Id
        JOIN Powers p ON ps.Power_Id = p.Id
    GROUP BY a.Name
END

EXECUTE usp_PowersUsageByAlignment