USE BLOG 
GO

CREATE TABLE BLOGS 
(
	ID INT IDENTITY(1,1) NOT NULL,
	TITLE NVARCHAR(MAX) NOT NULL,
	DESCRIPTION_SHORT NVARCHAR(MAX),
	DETAIL NVARCHAR(MAX), 
	IMAGE VARCHAR(MAX),
	CATEGORY INT NOT NULL,
	LOCATIONS NVARCHAR(MAX) NOT NULL,
	PUBLICS BIT NOT NULL,
	DATE_PUBLIC DATE NOT NULL
)
GO

-- search tiêu đề
-- thêm mới, update, xóa 

ALTER PROC proc_CRUD_Blogs 
	@ID INT ,
	@TITLE NVARCHAR(MAX),
	@DESCRIPTION_SHORT NVARCHAR(MAX),
	@DETAIL NVARCHAR(MAX),
	@IMAGE VARCHAR(max),
	@CATEGORY INT,
	@LOCATION NVARCHAR(MAX),
	@PUBLICS BIT,
	@DATE_PUBLIC DATE,
	@TITLE_INPUT NVARCHAR(MAX) = NULL,
	@QUERY INT 
AS
BEGIN
	IF (@Query = 1) -- search 
	BEGIN
	    SELECT ID, TITLE, CATEGORY, PUBLICS, DATE_PUBLIC
		FROM dbo.BLOGS
		WHERE TITLE LIKE @TITLE_INPUT + '%'
		SELECT 'Search'
	END
	IF (@Query = 2) -- insert
	BEGIN
	    INSERT INTO dbo.BLOGS
		(
			TITLE,
			DESCRIPTION_SHORT,
			DETAIL,
			IMAGE,
			CATEGORY,
			LOCATIONS,
			PUBLICS,
			DATE_PUBLIC
		)
		VALUES
		(   @TITLE,      -- TITLE - nvarchar(max)
			@DESCRIPTION_SHORT,      -- DESCRIPTION_SHORT - nvarchar(max)
			@DETAIL,      -- DETAIL - nvarchar(max)
			@IMAGE,     -- IMAGE - image
			@CATEGORY,        -- CATEGORY - int
			@LOCATION,      -- LOCATIONS - nvarchar(max)
			@PUBLICS,     -- PUBLICS - bit
			GETDATE() -- DATE_PUBLIC - date
		)
		IF (@@ROWCOUNT > 0)  
			BEGIN  
				SELECT 'Insert'  
			END 
	END
	IF (@Query = 3) -- update
	BEGIN
	    UPDATE dbo.BLOGS
			SET 
				TITLE = @TITLE,
				DESCRIPTION_SHORT = @Description_Short,
				DETAIL = @Detail,
				IMAGE = @IMAGE,
				CATEGORY = @CATEGORY,
				LOCATIONS = @LOCATION,
				PUBLICS = @PUBLICS,
				DATE_PUBLIC = @Date_Public
			WHERE ID = @ID
		IF @@ROWCOUNT = 0  
			PRINT 'Warning: No rows were updated';  
		SELECT 'update'
	END
	IF (@Query = 4) -- delete
	BEGIN
	    DELETE FROM dbo.BLOGS 
			WHERE ID = @ID
		SELECT 'delete'
	END
	IF (@Query = 5) -- list 
	BEGIN
	    SELECT *
		FROM dbo.BLOGS
		SELECT 'list'
	END
END
GO

EXEC dbo.proc_CRUD_Blogs @ID = NULL,                     -- int
                         @TITLE = NULL,               -- nvarchar(max)
                         @Description_Short = NULL,    -- nvarchar(max)
                         @Detail = NULL,               -- nvarchar(max)
                         @IMAGE = NULL,                 -- varchar(max)
                         @CATEGORY = NULL,               -- int
                         @LOCATION = NULL,             -- nvarchar(max)
                         @PUBLICS = NULL,              -- bit
                         @Date_Public = NULL, -- date
                         @TITLE_INPUT = NULL,          -- nvarchar(max)
                         @Query = 5              -- int
GO

