namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicialbd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnos",
                c => new
                    {
                        AlumnoId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 80),
                        Dni = c.String(nullable: false, maxLength: 8),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Correo = c.String(),
                        Genero = c.String(),
                        Celular = c.String(nullable: false, maxLength: 9),
                        Direccion = c.String(nullable: false, maxLength: 40),
                        Estado = c.Boolean(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlumnoId)
                .ForeignKey("dbo.Ubigeo", t => t.UbigeoId)
                .Index(t => t.UbigeoId);
            
            CreateTable(
                "dbo.EntregaDocuentos",
                c => new
                    {
                        EntregaDocuentosId = c.Int(nullable: false, identity: true),
                        DocumentosId = c.Int(nullable: false),
                        AlumnoId = c.Int(nullable: false),
                        Entregado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EntregaDocuentosId)
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId)
                .ForeignKey("dbo.Documentos", t => t.DocumentosId)
                .Index(t => t.DocumentosId)
                .Index(t => t.AlumnoId);
            
            CreateTable(
                "dbo.Documentos",
                c => new
                    {
                        DocumentosId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DocumentosId);
            
            CreateTable(
                "dbo.Matricula",
                c => new
                    {
                        MatriculaId = c.Int(nullable: false, identity: true),
                        AlumnoId = c.Int(nullable: false),
                        ApoderadoId = c.Int(nullable: false),
                        AnioAcademicoId = c.Int(nullable: false),
                        SeccionId = c.Int(nullable: false),
                        ParentescoId = c.Int(nullable: false),
                        RegularId = c.Int(),
                        CursoId = c.Int(),
                        NotasId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MatriculaId)
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId)
                .ForeignKey("dbo.Apoderado", t => t.ApoderadoId)
                .ForeignKey("dbo.Seccion", t => t.SeccionId)
                .ForeignKey("dbo.AnioAcademico", t => t.AnioAcademicoId)
                .ForeignKey("dbo.Parentesco", t => t.ParentescoId)
                .ForeignKey("dbo.Curso", t => t.CursoId)
                .ForeignKey("dbo.Notas", t => t.NotasId)
                .Index(t => t.AlumnoId)
                .Index(t => t.ApoderadoId)
                .Index(t => t.AnioAcademicoId)
                .Index(t => t.SeccionId)
                .Index(t => t.ParentescoId)
                .Index(t => t.CursoId)
                .Index(t => t.NotasId);
            
            CreateTable(
                "dbo.AnioAcademico",
                c => new
                    {
                        AnioAcademicoId = c.Int(nullable: false, identity: true),
                        Activo = c.Boolean(nullable: false),
                        FechaApertura = c.DateTime(nullable: false),
                        FechaClausura = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AnioAcademicoId);
            
            CreateTable(
                "dbo.Horario",
                c => new
                    {
                        HorarioId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        Horafin = c.DateTime(nullable: false),
                        CursoId = c.Int(nullable: false),
                        AnioAcademicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HorarioId)
                .ForeignKey("dbo.AnioAcademico", t => t.AnioAcademicoId)
                .ForeignKey("dbo.Curso", t => t.CursoId)
                .Index(t => t.CursoId)
                .Index(t => t.AnioAcademicoId);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 70),
                        GradoId = c.Int(nullable: false),
                        SeccionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoId)
                .ForeignKey("dbo.Grado", t => t.GradoId)
                .ForeignKey("dbo.Seccion", t => t.SeccionId)
                .Index(t => t.GradoId)
                .Index(t => t.SeccionId);
            
            CreateTable(
                "dbo.Docente",
                c => new
                    {
                        DocenteId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 80),
                        correo = c.String(nullable: false, maxLength: 8),
                        masculino = c.Boolean(nullable: false),
                        Femenino = c.Boolean(nullable: false),
                        Celular = c.String(nullable: false, maxLength: 9),
                        Direccion = c.String(nullable: false, maxLength: 40),
                        EspecialidadId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocenteId)
                .ForeignKey("dbo.Curso", t => t.CursoId)
                .ForeignKey("dbo.Especialidad", t => t.EspecialidadId)
                .ForeignKey("dbo.Ubigeo", t => t.UbigeoId)
                .Index(t => t.EspecialidadId)
                .Index(t => t.CursoId)
                .Index(t => t.UbigeoId);
            
            CreateTable(
                "dbo.Especialidad",
                c => new
                    {
                        EspecialidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EspecialidadId);
            
            CreateTable(
                "dbo.Ubigeo",
                c => new
                    {
                        UbigeoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 80),
                        Departamento = c.String(nullable: false, maxLength: 80),
                        Provincia = c.String(nullable: false, maxLength: 80),
                        Distrito = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.UbigeoId);
            
            CreateTable(
                "dbo.Apoderado",
                c => new
                    {
                        ApoderadoId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 80),
                        Dni = c.String(nullable: false, maxLength: 8),
                        masculino = c.Boolean(nullable: false),
                        Femenino = c.Boolean(nullable: false),
                        Celular = c.String(nullable: false, maxLength: 9),
                        Direccion = c.String(nullable: false, maxLength: 40),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApoderadoId)
                .ForeignKey("dbo.Ubigeo", t => t.UbigeoId)
                .Index(t => t.UbigeoId);
            
            CreateTable(
                "dbo.Grado",
                c => new
                    {
                        GradoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        NivelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradoId)
                .ForeignKey("dbo.Nivel", t => t.NivelId)
                .Index(t => t.NivelId);
            
            CreateTable(
                "dbo.Nivel",
                c => new
                    {
                        NivelId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.NivelId);
            
            CreateTable(
                "dbo.Seccion",
                c => new
                    {
                        SeccionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Capacidad = c.Int(nullable: false),
                        GradoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeccionId)
                .ForeignKey("dbo.Grado", t => t.GradoId)
                .Index(t => t.GradoId);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        NotasId = c.Int(nullable: false, identity: true),
                        BimestreId = c.Int(nullable: false),
                        AlumnoId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                        Nota = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NotasId)
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId)
                .ForeignKey("dbo.Bimestre", t => t.BimestreId)
                .ForeignKey("dbo.Curso", t => t.CursoId)
                .Index(t => t.BimestreId)
                .Index(t => t.AlumnoId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Bimestre",
                c => new
                    {
                        BimestreId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BimestreId);
            
            CreateTable(
                "dbo.Parentesco",
                c => new
                    {
                        ParentescoId = c.Int(nullable: false, identity: true),
                        tipo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ParentescoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matricula", "NotasId", "dbo.Notas");
            DropForeignKey("dbo.Matricula", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.Matricula", "ParentescoId", "dbo.Parentesco");
            DropForeignKey("dbo.Matricula", "AnioAcademicoId", "dbo.AnioAcademico");
            DropForeignKey("dbo.Notas", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.Notas", "BimestreId", "dbo.Bimestre");
            DropForeignKey("dbo.Notas", "AlumnoId", "dbo.Alumnos");
            DropForeignKey("dbo.Horario", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.Matricula", "SeccionId", "dbo.Seccion");
            DropForeignKey("dbo.Seccion", "GradoId", "dbo.Grado");
            DropForeignKey("dbo.Curso", "SeccionId", "dbo.Seccion");
            DropForeignKey("dbo.Grado", "NivelId", "dbo.Nivel");
            DropForeignKey("dbo.Curso", "GradoId", "dbo.Grado");
            DropForeignKey("dbo.Docente", "UbigeoId", "dbo.Ubigeo");
            DropForeignKey("dbo.Apoderado", "UbigeoId", "dbo.Ubigeo");
            DropForeignKey("dbo.Matricula", "ApoderadoId", "dbo.Apoderado");
            DropForeignKey("dbo.Alumnos", "UbigeoId", "dbo.Ubigeo");
            DropForeignKey("dbo.Docente", "EspecialidadId", "dbo.Especialidad");
            DropForeignKey("dbo.Docente", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.Horario", "AnioAcademicoId", "dbo.AnioAcademico");
            DropForeignKey("dbo.Matricula", "AlumnoId", "dbo.Alumnos");
            DropForeignKey("dbo.EntregaDocuentos", "DocumentosId", "dbo.Documentos");
            DropForeignKey("dbo.EntregaDocuentos", "AlumnoId", "dbo.Alumnos");
            DropIndex("dbo.Notas", new[] { "CursoId" });
            DropIndex("dbo.Notas", new[] { "AlumnoId" });
            DropIndex("dbo.Notas", new[] { "BimestreId" });
            DropIndex("dbo.Seccion", new[] { "GradoId" });
            DropIndex("dbo.Grado", new[] { "NivelId" });
            DropIndex("dbo.Apoderado", new[] { "UbigeoId" });
            DropIndex("dbo.Docente", new[] { "UbigeoId" });
            DropIndex("dbo.Docente", new[] { "CursoId" });
            DropIndex("dbo.Docente", new[] { "EspecialidadId" });
            DropIndex("dbo.Curso", new[] { "SeccionId" });
            DropIndex("dbo.Curso", new[] { "GradoId" });
            DropIndex("dbo.Horario", new[] { "AnioAcademicoId" });
            DropIndex("dbo.Horario", new[] { "CursoId" });
            DropIndex("dbo.Matricula", new[] { "NotasId" });
            DropIndex("dbo.Matricula", new[] { "CursoId" });
            DropIndex("dbo.Matricula", new[] { "ParentescoId" });
            DropIndex("dbo.Matricula", new[] { "SeccionId" });
            DropIndex("dbo.Matricula", new[] { "AnioAcademicoId" });
            DropIndex("dbo.Matricula", new[] { "ApoderadoId" });
            DropIndex("dbo.Matricula", new[] { "AlumnoId" });
            DropIndex("dbo.EntregaDocuentos", new[] { "AlumnoId" });
            DropIndex("dbo.EntregaDocuentos", new[] { "DocumentosId" });
            DropIndex("dbo.Alumnos", new[] { "UbigeoId" });
            DropTable("dbo.Parentesco");
            DropTable("dbo.Bimestre");
            DropTable("dbo.Notas");
            DropTable("dbo.Seccion");
            DropTable("dbo.Nivel");
            DropTable("dbo.Grado");
            DropTable("dbo.Apoderado");
            DropTable("dbo.Ubigeo");
            DropTable("dbo.Especialidad");
            DropTable("dbo.Docente");
            DropTable("dbo.Curso");
            DropTable("dbo.Horario");
            DropTable("dbo.AnioAcademico");
            DropTable("dbo.Matricula");
            DropTable("dbo.Documentos");
            DropTable("dbo.EntregaDocuentos");
            DropTable("dbo.Alumnos");
        }
    }
}
