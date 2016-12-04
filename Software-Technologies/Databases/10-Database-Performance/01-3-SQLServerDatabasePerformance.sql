CREATE TABLE LogsDB(
  Id int NOT NULL IDENTITY,
  LogDate datetime,
  LogText nvarchar(300),
  CONSTRAINT PK_Logs_Id PRIMARY KEY (Id)
)

GO
--drop proc usp_AddOneMilionLogs
CREATE PROC usp_AddOneMilionLogs
AS
DECLARE @counter int
SET @counter = 1;
WHILE(@counter < 10000000)
BEGIN
  DECLARE @Date datetime
	SET @Date = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
	INSERT INTO LogsDB ([LogDate], [LogText])
	VALUES(@Date, 'dsd')
	SET @counter = @counter + 1;
END
GO
--filled 2 000 000 logs for 12 minutes...and i have stopped it

EXEC usp_AddOneMilionLogs

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

----------------------------TASK 1--------------------------------
SELECT l.LogDate
FROM LogsDB l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001

--RESULT:
-- 3sec. without cache
-- 2sec. with cache

----------------------------TASK 2--------------------------------

CREATE INDEX IDX_LogsDB_LogDate ON LogsDB(LogDate)

DROP INDEX LogsDB.IDX_Logs_LogDate
--indexes created for 8sec.

SELECT l.LogDate
FROM LogsDB l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001
--no difference for 2 000 000 logs

----------------------------TASK 3--------------------------------
DROP INDEX LogsDB.IDX_Logs_LogDate

CREATE INDEX IDX_LogsDB_MsgText ON LogsDB(LogText)

SELECT l.LogText
FROM LogsDB l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001
-- without cache 4 sec no index and the same with index
-- with cache 3 sec no index and the same with index