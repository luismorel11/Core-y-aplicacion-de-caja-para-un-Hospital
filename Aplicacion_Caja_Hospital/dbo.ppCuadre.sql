CREATE PROCEDURE [dbo].ppCuadre
(
	@Administrador nvarchar(50),
	@Entrada decimal(18, 0),
	@Salida decimal(18, 0),
	@Deposito decimal(18, 0),
	@Retiro decimal(18, 0),
	@PagoPrestamo decimal(18, 0)
)
AS

	if not exists (select 1 from tblCuadre where Administrador = @Administrador)
		insert into tblCuadre(Administrador, Entrada, Salida, Deposito, Retiro, PagoPrestamo) 
				values(@Administrador, @Entrada, @Salida, @Deposito, @Retiro, @PagoPrestamo)
	else
		update tblCuadre set Entrada = Entrada + @Entrada, Salida = Salida + @Salida, Deposito = Deposito + @Deposito, Retiro = Retiro + @Retiro, PagoPrestamo = PagoPrestamo + @PagoPrestamo 
	
RETURN 0