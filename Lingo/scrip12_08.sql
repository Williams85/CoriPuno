USE [bdcarguio]
GO
/****** Object:  View [dbo].[vcombinalabor]    Script Date: 08/12/2018 00:23:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vcombinalabor]
AS
SELECT     A.id_origen, B.id_DESTINO, C.nDistancia, C.id_ruta
FROM         (SELECT     ID_LABOR AS id_origen
                       FROM          dbo.MLABOR
                       WHERE      (tipo = 'OR') AND (estado = 'A')) AS A CROSS JOIN
                          (SELECT     ID_LABOR AS id_DESTINO
                            FROM          dbo.MLABOR AS MLABOR_1
                            WHERE      (tipo = 'DE') AND (estado = 'A')) AS B INNER JOIN
                      dbo.MRutas AS C ON A.id_origen = C.id_origen AND B.id_DESTINO = C.id_Destino
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[3] 2[23] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "C"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 125
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "A"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 80
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 84
               Left = 38
               Bottom = 158
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 2835
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vcombinalabor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vcombinalabor'
GO
/****** Object:  View [dbo].[vLABOR_ORIGEN]    Script Date: 08/12/2018 00:23:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vLABOR_ORIGEN]
AS
SELECT     A.ID_LABOR, A.ley
FROM         dbo.MLABOR AS A INNER JOIN
                          (SELECT     id_origen
                            FROM          dbo.vcombinalabor
                            GROUP BY id_origen) AS B ON A.ID_LABOR = B.id_origen
WHERE     (A.estado = 'A') AND (A.tipo = 'OR')
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "A"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 80
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vLABOR_ORIGEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vLABOR_ORIGEN'
GO
/****** Object:  View [dbo].[vlabor_destino]    Script Date: 08/12/2018 00:23:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vlabor_destino]
AS
SELECT     A.ID_LABOR, A.nCapMaxima
FROM         dbo.MLABOR AS A INNER JOIN
                          (SELECT     id_DESTINO
                            FROM          dbo.vcombinalabor
                            GROUP BY id_DESTINO) AS B ON A.ID_LABOR = B.id_DESTINO
WHERE     (A.tipo = 'DE') AND (A.estado = 'A')
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "A"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 80
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vlabor_destino'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vlabor_destino'
GO
/****** Object:  View [dbo].[vNroitems]    Script Date: 08/12/2018 00:23:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vNroitems]
AS
SELECT     SUM(nreg) AS nreg, SUM(laor) AS laor, SUM(lade) AS lade
FROM         (SELECT     COUNT(*) AS nreg, 0 AS laor, 0 AS lade
                       FROM          dbo.vStock_disponible
                       UNION
                       SELECT     0 AS Expr1, COUNT(*) AS Expr2, 0 AS Expr3
                       FROM         dbo.vLABOR_ORIGEN
                       UNION
                       SELECT     0 AS Expr1, 0 AS Expr2, COUNT(*) AS Expr3
                       FROM         dbo.vlabor_destino) AS derivedtbl_1
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[21] 2[18] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "derivedtbl_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 110
               Right = 252
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vNroitems'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vNroitems'
GO
/****** Object:  StoredProcedure [dbo].[cargaprograma]    Script Date: 08/12/2018 00:23:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Author:		<Ronald Gates>

-- Create date: <16-02-17>

-- Description:	<cargar archivo de programa y ejecuta lingo,>

-- =============================================


CREATE PROCEDURE [dbo].[cargaprograma] @fecha datetime, @turno varchar(10),@leymin numeric(10,4),@leymax numeric(10,4),@codmes int OUTPUT AS



BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from

	-- interfering with SELECT statements.

	-- mensajes de error

	-- 5 no existe labores origen activas

	-- 4 No existe labores destino activa

	-- 3 Programa ya ha sido generado y cerrado

	-- 2 Programa regenerado

	-- 1 Nuevo programa generado

	SET NOCOUNT ON;

	declare @nreg int,@nlabor int,@nlabde int,@estado char(1)

	set @nreg= isnull((select count(*) from dprogramacionDiaria_Cab where Fecha=@fecha and turno=@turno),0)

	set @estado= ISNULL((select estado from dprogramacionDiaria_Cab where Fecha=@fecha and turno=@turno),'')

	set @nlabor=(select COUNT(id_labor) from MLABOR where tipo='OR' AND estado='A' )

	set @nlabde=(select COUNT(id_labor) from MLABOR where tipo='DE' AND estado='A' )

	if @nlabor = 0 

	   set @codmes=5

	if @nlabde=0

	   set @codmes=4

	IF @nreg>0 AND @ESTADO='C'

	   set @codmes=3

	if ISNULL(@codmes,0)<3

	   begin   

	       if @nreg=1 and  @estado=''  

	         begin

	            update dprogramacionDiaria_Cab set nleymin=@leymin,nleymax=@leymax

                where Fecha=@fecha and turno=@turno

	            set @codmes=2

	         end

           IF @nreg=0  -- nuevo registro

              begin 

                 -- CREANDO CABECERA

                 insert into dprogramacionDiaria_Cab (Fecha,turno,nleymin,nleymax,año,mes,NlabOr,nLaborde)

                 VALUES (@fecha,@turno,@leymin,@leymax,YEAR(@FECHA),MONTH(@FECHA),@nlabor,@nlabde)

                 if ISNULL(@codmes,0)=0

                    set @codmes=1

               end

       

               

         --  if @codmes<>1

         --     begin

         --       set @codmes=2

         --        update dprogramacionDiaria_Cab set nleymin=@leymin,nleymax=@leymax

         --        where Fecha=@fecha and turno=@turno

         --     end   

                

              delete from dprogramacionDiaria_tmp 

              insert into dprogramacionDiaria_tmp (fecha,turno,ccordina,nleymin,nleymax,nCostoAprox,nleyPromedio,año,mes,estado,nlabOr,nlaborde)

              select fecha,turno,ccordina,nleymin,nleymax,nCostoAprox,nleyPromedio,año,mes,estado,nlabOr,nlaborde from dprogramacionDiaria_Cab where Fecha=@fecha and turno=@turno

            -- ALTER TABLE dbo.dcombinalabor NOCHECK CONSTRAINT FK_dProgramacionDiaria_dcombinalabor 

             DELETE FROM dcombinalabor

            -- ALTER TABLE dbo.dcombinalabor CHECK CONSTRAINT FK_dProgramacionDiaria_dcombinalabor


            --  DELETE FROM dcombinalabor

              INSERT INTO dcombinalabor(Labor_or,Labor_de,distancia)

              SELECT ID_ORIGEN,ID_DESTINO,nDistancia FROM vcombinalabor

              

              EXEC XP_CMDSHELL 'C:\CoriPuno v3.0\Lingo\generaPrograma.bat'

              

              delete from dProgramacionDiaria where fini=@fecha and turno=@turno

              insert into dProgramacionDiaria
			  (año, mes, fini, feceje, turno, Labor_or, Ley, labor_de, CapMaxima, distancia, nTonMet, id_equipo)

              select YEAR(@FECHA),MONTH(@FECHA),@fecha,@fecha,@turno,a.labor_or,b.ley,a.labor_de,c.ncapMaxima,a.distancia,a.tm ,0

                from dcombinalabor a

                      inner join vlabor_origen b on a.Labor_or=b.ID_LABOR

                      inner join vlabor_destino c on a.labor_de=c.id_labor

                 where a.TM>0

                 

              update dprogramacionDiaria_Cab set nCostoAprox = (select nCostoAprox from dprogramacionDiaria_tmp),

                                                 nLeyPromedio= (select AVG(Ley) from dProgramacionDiaria where fini=@fecha and turno=@turno)

              where Fecha=@fecha and turno=@turno   

              

       end 

	

END

if ISNULL(@codmes,0)=0

   set @codmes=2

   

return
GO
