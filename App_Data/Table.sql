USE BLOG 
GO

CREATE TABLE BLOGS 
(
	ID INT IDENTITY(1,1) NOT NULL,
	TITLE NVARCHAR(MAX) NOT NULL,
	DESCRIPTION_SHORT NVARCHAR(MAX),
	DETAIL NVARCHAR(MAX), 
	IMAGE VARCHAR(MAX),
	CATEGORY NVARCHAR(MAX) NOT NULL,
	LOCATIONS NVARCHAR(MAX) NOT NULL,
	PUBLICS NVARCHAR(MAX) NOT NULL,
	DATE_PUBLIC DATE NOT NULL
)
GO

DROP TABLE dbo.BLOGS
DELETE dbo.BLOGS

-- search tiêu đề
-- thêm mới, update, xóa 

ALTER PROCEDURE proc_CRUD_Blogs_2 
	@ID INT = NULL,
	@TITLE NVARCHAR(MAX) = NULL,
	@DESCRIPTION_SHORT NVARCHAR(MAX) = NULL,
	@DETAIL NVARCHAR(MAX) = NULL,
	@IMAGE VARCHAR(max) = NULL,
	@CATEGORY NVARCHAR(MAX) = NULL,
	@LOCATION NVARCHAR(MAX) = NULL,
	@PUBLICS NVARCHAR(MAX) = NULL,
	@DATE_PUBLIC DATE = NULL,
	@TITLE_INPUT NVARCHAR(MAX) = NULL,
	@ID_INPUT INT = NULL,
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
	    SELECT * FROM dbo.BLOGS
		SELECT 'list'
	END
	IF (@Query = 6) -- selectDataById
	BEGIN
	    SELECT *
		FROM dbo.BLOGS
		WHERE ID = @ID_INPUT
	END
END
GO

DROP	PROC dbo.proc_CRUD_Blogs_2

EXEC dbo.proc_CRUD_Blogs_2 @ID = NULL,                     -- int
                           @TITLE = NULL,                -- nvarchar(max)
                           @DESCRIPTION_SHORT = NULL,    -- nvarchar(max)
                           @DETAIL = NULL,               -- nvarchar(max)
                           @IMAGE = NULL,                 -- varchar(max)
                           @CATEGORY = NULL,               -- int
                           @LOCATION = NULL,             -- nvarchar(max)
                           @PUBLICS = NULL,             -- bit
                           @DATE_PUBLIC = NULL, -- date
                           @TITLE_INPUT = 'V',          -- nvarchar(max)
                           @QUERY = 1                   -- int



INSERT INTO dbo.BLOGS
(
    TITLE,
    DESCRIPTION_SHORT,
    DETAIL,
    CATEGORY,
    LOCATIONS,
    PUBLICS,
    DATE_PUBLIC,
    IMAGE
)
VALUES
(   N'Việt Nam phát hiện 2 ca Covid-19 ngoài cộng đồng, Bộ Y tế họp khẩn',       -- TITLE - nvarchar(max)
    N'Sáng 28/1, Bộ Y tế thông tin nước ta phát hiện 2 ca lây nhiễm Covid-19 ngoài cộng đồng gồm một nhân viên cảng hàng không Vân Đồn và một người phụ nữ Hải Dương.',       -- DESCRIPTION_SHORT - nvarchar(max)
    N'CA BỆNH 1552 (BN 1552): nữ, 34 tuổi, quốc tịch Việt Nam, nghề nghiệp là công nhân công ty TNHH POYUN, có địa chỉ thường trú tại Kim Điền, xã Hưng Đạo, TP Chí Linh, tỉnh Hải Dương.

Bệnh nhân có giao tiếp gần với bệnh nhân nữ được phát hiện dương tính sau khi nhập cảnh Osaka (Nhật Bản). Bệnh nhân đã được cách ly tập trung và lấy mẫu xét nghiệm. Kết quả xét nghiệm tối 27/1 khẳng định bệnh nhân dương tính với SARS-CoV-2.

Hiện bệnh nhân được cách ly điều trị tại Bệnh viện Bệnh Nhiệt đới Trung ương cơ sở Đông Anh (Hà Nội).

CA BỆNH 1553 (BN 1553): nam, 31 tuổi, quốc tịch Việt Nam, nghề nghiệp nhân viên Cảng hàng không Vân Đồn, có địa chỉ thường trú tại phường Hồng Hà, TP Hạ Long, tỉnh Quảng Ninh.

Do có biểu hiện sốt, ho khan, đau họng, bệnh nhân đã tự đến bệnh viện khám. Bệnh viện đã lấy mẫu bệnh phẩm, kết quả xét nghiệm tối 27/1 của Trung tâm Kiểm soát Bệnh tật Quảng Ninh khẳng định bệnh nhân dương tính với SARS-CoV-2.

Hiện bệnh nhân được cách ly điều trị tại Bệnh viện Bệnh Nhiệt đới Trung ương cơ sở Đông Anh.',       -- DETAIL - nvarchar(max)
    N'Thời sự',         -- CATEGORY - int
    N'Việt Nam',       -- LOCATIONS - nvarchar(max)
    N'Yes',      -- PUBLICS - bit
    GETDATE(), -- DATE_PUBLIC - date
    NULL        -- IMAGE - varchar(max)
    )
GO

INSERT INTO dbo.BLOGS
(
    TITLE,
    DESCRIPTION_SHORT,
    DETAIL,
    CATEGORY,
    LOCATIONS,
    PUBLICS,
    DATE_PUBLIC,
    IMAGE
)
VALUES
(   N'Bệnh nhân Covid-19 ở Quảng Ninh đã đi họp lớp, hát karaoke, ăn đêm...',       -- TITLE - nvarchar(max)
    N'Quảng Ninh vừa công bố lịch trình di chuyển của bệnh nhân Covid-19 ngoài cộng đồng. Bệnh nhân từng đi hát karaoke, uống cafe, họp lớp, ăn đêm...',       -- DESCRIPTION_SHORT - nvarchar(max)
    N'',       -- DETAIL - nvarchar(max)
    N'Thời sự',         -- CATEGORY - int
    N'Việt Nam',       -- LOCATIONS - nvarchar(max)
    N'No',      -- PUBLICS - bit
    GETDATE(), -- DATE_PUBLIC - date
   NULL        -- IMAGE - varchar(max)
    )
	GO
    
INSERT INTO dbo.BLOGS
(
    TITLE,
    DESCRIPTION_SHORT,
    DETAIL,
    CATEGORY,
    LOCATIONS,
    PUBLICS,
    DATE_PUBLIC,
    IMAGE
)
VALUES
(   N'Man Utd 1-2 Sheffield Utd: Địa chấn ở Old Trafford',       -- TITLE - nvarchar(max)
    N'Man Utd gây bất ngờ khi thua đội bét bảng Sheffield Utd trên sân nhà ở lượt trận đầu tiên của lượt về, vòng 20 Premier League. Thua trận, Man Utd kém đội đầu bảng Man City 1 điểm.',       -- DESCRIPTION_SHORT - nvarchar(max)
    N'Man Utd đánh mất ngôi đầu bảng không phải việc gây ra nhiều ngạc nhiên, năng lực đua đường dài của "Quỷ đỏ" vẫn bị nghi ngờ. Nhưng việc họ thua đội bét bảng Sheffield Utd ngay trên sân nhà quả thật là điều vô cùng bất ngờ.

Sheffield Utd mới chỉ thắng duy nhất một trận sau lượt đi, họ chỉ có 5 điểm và có lẽ đội bóng này đã cầm chắc một vé xuống hạng. Dẫu vậy, Man Utd lại không thể giành điểm trước Sheffield Utd.

Bryan mở tỉ số cho đội khách với một tình huống đánh đầu sau quả phạt góc ở phút 23. Mãi tới phút 64, Maguire mới giúp đội chủ nhà gỡ hòa 1-1. Tuy nhiên hy vọng chiến thắng của Man Utd chỉ kéo dài có 10 phút. Phút 74, Burke ghi bàn nâng tỉ số lên 2-1 và đó là bàn thắng mang lại ba điểm trọn vẹn cho Sheffield Utd.',       -- DETAIL - nvarchar(max)
    N'Thể thao',         -- CATEGORY - int
    N'Châu Âu',       -- LOCATIONS - nvarchar(max)
    N'Yes',      -- PUBLICS - bit
    GETDATE(), -- DATE_PUBLIC - date
   NULL       -- IMAGE - varchar(max)
    )
GO

INSERT INTO dbo.BLOGS
(
    TITLE,
    DESCRIPTION_SHORT,
    DETAIL,
    CATEGORY,
    LOCATIONS,
    PUBLICS,
    DATE_PUBLIC,
    IMAGE
)
VALUES
(   N'Những người "siêu giàu" ở quanh ta',       -- TITLE - nvarchar(max)
    N'Vấn đề là pháp luật về thuế và năng lực của cơ quan quản lý cần đi kịp với thực tế, chứ không phải là "không quản được thì cấm".',       -- DESCRIPTION_SHORT - nvarchar(max)
    N'Năm hết tết đến, những thông tin về hoạt động nộp thuế của một số cá nhân nổi bật được phía cơ quan thuế đưa ra thu hút đông đảo sự quan tâm của độc giả. Bởi đằng sau câu chuyện thuế phí cũng lộ diện những khoản thu nhập cực "khủng" của người nộp thuế.

Theo thông tin của Chi cục Thuế Quận Cầu Giấy, một cô gái sinh năm 1992 tại Hà Nội mới đây đã nộp các nghĩa vụ thuế lên tới 23 tỷ đồng trong năm 2020, tương ứng với thu nhập trong năm đạt hơn 330 tỷ đồng. Một con số khó tin với hầu hết người dân còn với một cô gái trẻ ở thế hệ 9X càng gây choáng váng, nể phục!

Kế đến, ngày 26/1, Chi cục Thuế quận Hải Châu (TP Đà Nẵng) xác nhận vừa truy thu tiền thuế một cá nhân số tiền 25,3 tỷ đồng vì người này có thu nhập hơn 281 tỷ đồng từ nguồn quảng cáo trên mạng.',       -- DETAIL - nvarchar(max)
    N'Kinh doanh',         -- CATEGORY - int
    N'Việt Nam',       -- LOCATIONS - nvarchar(max)
    N'No',      -- PUBLICS - bit
    GETDATE(), -- DATE_PUBLIC - date
    NULL         -- IMAGE - varchar(max)
    )
	GO
    