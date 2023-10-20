using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructura.Data;
using Infrastructure.Repository;


namespace Infrastructura.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork,IDisposable
    {
        private readonly RopaContext _context;

        private ICargo _Cargos;

        private ICliente _Clientes;

        private IColor _Colores;

        private IDepartamento _Departamentos;

        private IDetalleOrden _DetallesOrdenes;

        private IDetalleVenta _DetallesVentas;

        private IEmpleado _Empleados;

        private IEmpresa _Empresas;

        private IEstado _Estados;

        private IFormaPago _FormasPagos;

        private IGenero _Generos;

        private IInsumo _Insumos;

        private IInsumoPrenda _InsumosPrendas;

        private IInsumoProveedor _InsumosProveedores;

        private IInventario _Inventarios;

        private IInventarioTalla _InventariosTallas;

        private IMunicipio _Municipios;

        private IOrden _Ordenes;

        private IPais _Paises;

        private IPrenda _Prendas;

        private IProveedor _Proveedores;

        private ITalla _Tallas;

        private ITipoEstado _TiposEstados;

        private ITipoPersona _TiposPersonas;

        private ITipoProteccion _TiposProtecciones;

        private IVenta _Ventas;

        public ICargo Cargos {
            get {
            if (_Cargos == null) {
                _Cargos = new CargoRepository(_context);
            }
            return _Cargos;
        }
        }

        public ICliente Clientes {
            get {
            if (_Clientes == null) {
                _Clientes = new ClienteRepository(_context);
            }
            return _Clientes;
        }
        }

        public IColor Colores {
            get {
            if (_Colores == null) {
                _Colores = new ColorRepository(_context);
            }
            return _Colores;
        }
        }

        public IDepartamento Departamentos {
            get {
            if (_Departamentos == null) {
                _Departamentos = new DepartamentoRepository(_context);
            }
            return _Departamentos;
        }
        }

        public IDetalleOrden DetallesOrdenes {
            get {
            if (_DetallesOrdenes == null) {
                _DetallesOrdenes = new DetalleOrdenRepository(_context);
            }
            return _DetallesOrdenes;
        }
        }

        public IDetalleVenta DetallesVentas {
            get {
            if (_DetallesVentas == null) {
                _DetallesVentas = new DetalleVentaRepository(_context);
            }
            return _DetallesVentas;
        }
        }

        public IEmpleado Empleados {
            get {
            if (_Empleados == null) {
                _Empleados = new EmpleadoRepository(_context);
            }
            return _Empleados;
        }
        }

        public IEmpresa Empresas {
            get {
            if (_Empresas == null) {
                _Empresas = new EmpresaRepository(_context);
            }
            return _Empresas;
        }
        }

        public IEstado Estados {
            get {
            if (_Estados == null) {
                _Estados = new EstadoRepository(_context);
            }
            return _Estados;
        }
        }

        public IFormaPago FormasPagos {
            get {
            if (_FormasPagos == null) {
                _FormasPagos = new FormaPagoRepository(_context);
            }
            return _FormasPagos;
        }
        }

        public IGenero Generos {
            get {
            if (_Generos == null) {
                _Generos = new GeneroRepository(_context);
            }
            return _Generos;
        }
        }

        public IInsumo Insumos {
            get {
            if (_Insumos == null) {
                _Insumos = new InsumoRepository(_context);
            }
            return _Insumos;
        }
        }

        public IInsumoPrenda InsumosPrendas {
            get {
            if (_InsumosPrendas == null) {
                _InsumosPrendas = new InsumoPrendaRepository(_context);
            }
            return _InsumosPrendas;
        }
        }

        public IInsumoProveedor InsumosProveedores {
            get {
            if (_InsumosProveedores == null) {
                _InsumosProveedores = new InsumoProveedorRepository(_context);
            }
            return _InsumosProveedores;
        }
        }

        public IInventario Inventarios {
            get {
            if (_Inventarios == null) {
                _Inventarios = new InventarioRepository(_context);
            }
            return _Inventarios;
        }
        }

        public IInventarioTalla InventariosTallas {
            get {
            if (_InventariosTallas == null) {
                _InventariosTallas = new InventarioTallaRepository(_context);
            }
            return _InventariosTallas;
        }
        }

        public IMunicipio Municipios {
            get {
            if (_Municipios == null) {
                _Municipios = new MunicipioRepository(_context);
            }
            return _Municipios;
        }
        }

        public IOrden Ordenes {
            get {
            if (_Ordenes == null) {
                _Ordenes = new OrdenRepository(_context);
            }
            return _Ordenes;
        }
        }

        public IPais Paises {
            get {
            if (_Paises == null) {
                _Paises = new PaisRepository(_context);
            }
            return _Paises;
        }
        }

        public IPrenda Prendas {
            get {
            if (_Prendas == null) {
                _Prendas = new PrendaRepository(_context);
            }
            return _Prendas;
        }
        }

        public IProveedor Proveedores {
            get {
            if (_Proveedores == null) {
                _Proveedores = new ProveedorRepository(_context);
            }
            return _Proveedores;
        }
        }

        public ITalla Tallas {
            get {
            if (_Tallas == null) {
                _Tallas = new TallaRepository(_context);
            }
            return _Tallas;
        }
        }

        public ITipoEstado TiposEstados {
            get {
            if (_TiposEstados == null) {
                _TiposEstados = new TipoEstadoRepository(_context);
            }
            return _TiposEstados;
        }
        }

        public ITipoPersona TiposPersonas {
            get {
            if (_TiposPersonas == null) {
                _TiposPersonas = new TipoPersonaRepository(_context);
            }
            return _TiposPersonas;
        }
        }

        public ITipoProteccion TiposProtecciones {
            get {
            if (_TiposProtecciones == null) {
                _TiposProtecciones = new TipoProteccionRepository(_context);
            }
            return _TiposProtecciones;
        }
        }

        public IVenta Ventas {
            get {
            if (_Ventas == null) {
                _Ventas = new VentaRepository(_context);
            }
            return _Ventas;
        }
        }

        public void Dispose()
				    {
				        _context.Dispose();
				    }
				
				    public async Task<int> SaveAsync()
				    {
				        return await _context.SaveChangesAsync();
				    }
				
        }
    }


