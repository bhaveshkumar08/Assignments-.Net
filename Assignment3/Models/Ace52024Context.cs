using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Aryan> Aryans { get; set; }

    public virtual DbSet<AryanSbaccount> AryanSbaccounts { get; set; }

    public virtual DbSet<AryanSbtransaction> AryanSbtransactions { get; set; }

    public virtual DbSet<Avika> Avikas { get; set; }

    public virtual DbSet<BhaveshSbaccount> BhaveshSbaccounts { get; set; }

    public virtual DbSet<BhaveshSbtransaction> BhaveshSbtransactions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Fpstudent> Fpstudents { get; set; }

    public virtual DbSet<Harshit> Harshits { get; set; }

    public virtual DbSet<Hetal> Hetals { get; set; }

    public virtual DbSet<HetalSbaccount> HetalSbaccounts { get; set; }

    public virtual DbSet<HetalSbtransaction> HetalSbtransactions { get; set; }

    public virtual DbSet<Ivy> Ivies { get; set; }

    public virtual DbSet<Jayendra> Jayendras { get; set; }

    public virtual DbSet<Jivanshu> Jivanshus { get; set; }

    public virtual DbSet<Kartik> Kartiks { get; set; }

    public virtual DbSet<KartikSbaccount> KartikSbaccounts { get; set; }

    public virtual DbSet<KartikSbtransaction> KartikSbtransactions { get; set; }

    public virtual DbSet<Krina> Krinas { get; set; }

    public virtual DbSet<KrinaSbaccount> KrinaSbaccounts { get; set; }

    public virtual DbSet<KrinaSbtransaction> KrinaSbtransactions { get; set; }

    public virtual DbSet<KritikaA> KritikaAs { get; set; }

    public virtual DbSet<KritikaSbaccount> KritikaSbaccounts { get; set; }

    public virtual DbSet<KritikaSbtransaction> KritikaSbtransactions { get; set; }

    public virtual DbSet<Kush> Kushes { get; set; }

    public virtual DbSet<KushSba> KushSbas { get; set; }

    public virtual DbSet<KushSbt> KushSbts { get; set; }

    public virtual DbSet<Muskan> Muskans { get; set; }

    public virtual DbSet<Pragati> Pragatis { get; set; }

    public virtual DbSet<Prerna> Prernas { get; set; }

    public virtual DbSet<PriyankaSbaccount> PriyankaSbaccounts { get; set; }

    public virtual DbSet<PriyankaSbtransaction> PriyankaSbtransactions { get; set; }

    public virtual DbSet<Sandhya> Sandhyas { get; set; }

    public virtual DbSet<Sanskriti> Sanskritis { get; set; }

    public virtual DbSet<SanskritiSbaccount> SanskritiSbaccounts { get; set; }

    public virtual DbSet<SanskritiSbtransaction> SanskritiSbtransactions { get; set; }

    public virtual DbSet<SbAccountv> SbAccountvs { get; set; }

    public virtual DbSet<SbTransactionv> SbTransactionvs { get; set; }

    public virtual DbSet<SbaccountJay> SbaccountJays { get; set; }

    public virtual DbSet<SbaccountJivanshu> SbaccountJivanshus { get; set; }

    public virtual DbSet<Sbaccountivy> Sbaccountivies { get; set; }

    public virtual DbSet<Sbtransaction> Sbtransactions { get; set; }

    public virtual DbSet<SbtransactionJay> SbtransactionJays { get; set; }

    public virtual DbSet<SbtransactionsJivanshu> SbtransactionsJivanshus { get; set; }

    public virtual DbSet<Sbtransactionsivy> Sbtransactionsivies { get; set; }

    public virtual DbSet<Shivya> Shivyas { get; set; }

    public virtual DbSet<Stud> Studs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Student007> Student007s { get; set; }

    public virtual DbSet<Student1> Students1 { get; set; }

    public virtual DbSet<Student27> Student27s { get; set; }

    public virtual DbSet<Studentss> Studentsses { get; set; }

    public virtual DbSet<Studenttt> Studenttts { get; set; }

    public virtual DbSet<Studentttt> Studentttts { get; set; }

    public virtual DbSet<Suhasini> Suhasinis { get; set; }

    public virtual DbSet<SuhasiniSbaccount> SuhasiniSbaccounts { get; set; }

    public virtual DbSet<SuhasiniSbtransaction> SuhasiniSbtransactions { get; set; }

    public virtual DbSet<Suhasininew> Suhasininews { get; set; }

    public virtual DbSet<Suhasinitable> Suhasinitables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aryan>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__aryan__DDDFDD36A8A3380C");

            entity.ToTable("aryan");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<AryanSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__AryanSBA__BE2ACD6EFE99BFC6");

            entity.ToTable("AryanSBAccount");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AryanSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__AryanSBT__55433A6B71704635");

            entity.ToTable("AryanSBTransaction");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.AryanSbtransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__AryanSBTr__Accou__29221CFB");
        });

        modelBuilder.Entity<Avika>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__avika__DDDFDD36C4D1AF1A");

            entity.ToTable("avika");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<BhaveshSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__Bhavesh___BE2ACD6ED88BC83B");

            entity.ToTable("Bhavesh_SBAccount");

            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BhaveshSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Bhavesh___55433A6BB815F1BA");

            entity.ToTable("Bhavesh_SBTransaction");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.BhaveshSbtransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__Bhavesh_S__Accou__7EF6D905");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__employee__DDDFDD361B1D6E6A");

            entity.ToTable("employee");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Fpstudent>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Fpstuden__DDDFDD363121B9DB");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Harshit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__harshit__3213E83FAA22F92F");

            entity.ToTable("harshit");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
        });

        modelBuilder.Entity<Hetal>(entity =>
        {
            entity.HasKey(e => e.Sid);

            entity.ToTable("Hetal");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("SID");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<HetalSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNo);

            entity.ToTable("HetalSBAccount");

            entity.Property(e => e.CustomerAddress).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
        });

        modelBuilder.Entity<HetalSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("HetalSBTransaction");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType).HasMaxLength(15);
        });

        modelBuilder.Entity<Ivy>(entity =>
        {
            entity.HasKey(e => e.Siiid).HasName("PK__studentt__3DBE29A1E0962EC7");

            entity.ToTable("ivy");

            entity.Property(e => e.Siiid)
                .ValueGeneratedNever()
                .HasColumnName("siiid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Jayendra>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Jayendra__AA2FFBE5513A081B");

            entity.ToTable("Jayendra");

            entity.Property(e => e.PersonId).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jivanshu>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__jivanshu__D9509F6DF8E8E366");

            entity.ToTable("jivanshu");

            entity.Property(e => e.Eid)
                .ValueGeneratedNever()
                .HasColumnName("eid");
            entity.Property(e => e.Doj).HasColumnName("doj");
            entity.Property(e => e.Ename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ename");
        });

        modelBuilder.Entity<Kartik>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__kartik__CA195950483E7AEB");

            entity.ToTable("kartik");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("SId");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("dob");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SName");
        });

        modelBuilder.Entity<KartikSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__kartik_S__BE2ACD6EB81381A8");

            entity.ToTable("kartik_SBAccount");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KartikSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__kartik_S__55433A6BAB019EB7");

            entity.ToTable("kartik_SBTransactions");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.TransactionType)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Krina>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Krina__DDDFDD36EAC230E4");

            entity.ToTable("Krina");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<KrinaSbaccount>(entity =>
        {
            entity.HasKey(e => e.Accno).HasName("PK__Krina_SB__A472931D58519352");

            entity.ToTable("Krina_SBAccount");

            entity.Property(e => e.Accno)
                .ValueGeneratedNever()
                .HasColumnName("accno");
            entity.Property(e => e.Cname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cname");
            entity.Property(e => e.CurrAddr)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("curr_addr");
            entity.Property(e => e.CurrBal).HasColumnName("curr_bal");
        });

        modelBuilder.Entity<KrinaSbtransaction>(entity =>
        {
            entity.HasKey(e => e.Transid).HasName("PK__Krina_SB__DB1F6ABF0D13ADE4");

            entity.ToTable("Krina_SBTransaction");

            entity.Property(e => e.Transid)
                .ValueGeneratedNever()
                .HasColumnName("transid");
            entity.Property(e => e.Accno).HasColumnName("accno");
            entity.Property(e => e.Amt).HasColumnName("amt");
            entity.Property(e => e.Transdate)
                .HasColumnType("datetime")
                .HasColumnName("transdate");
            entity.Property(e => e.Tt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tt");

            entity.HasOne(d => d.AccnoNavigation).WithMany(p => p.KrinaSbtransactions)
                .HasForeignKey(d => d.Accno)
                .HasConstraintName("FK__Krina_SBT__accno__41EDCAC5");
        });

        modelBuilder.Entity<KritikaA>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__KritikaA__AF2DBA792D46F755");

            entity.ToTable("KritikaA");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("EmpID");
            entity.Property(e => e.Edept)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDept");
            entity.Property(e => e.Edoj).HasColumnName("EDoj");
            entity.Property(e => e.Ename)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EName");
        });

        modelBuilder.Entity<KritikaSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__KritikaS__BE2ACD6ED7EFCB04");

            entity.ToTable("KritikaSBAccount");

            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KritikaSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__KritikaS__55433A6B01EC6595");

            entity.ToTable("KritikaSBTransaction");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.Transactiontype)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.KritikaSbtransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("fka");
        });

        modelBuilder.Entity<Kush>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__kush__DDDFDD36992B3749");

            entity.ToTable("kush");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<KushSba>(entity =>
        {
            entity.HasKey(e => e.AccNo).HasName("PK__kushSBA__A47197055F427832");

            entity.ToTable("kushSBA");

            entity.Property(e => e.AccNo)
                .ValueGeneratedNever()
                .HasColumnName("accNo");
            entity.Property(e => e.CurrBal).HasColumnName("currBal");
            entity.Property(e => e.CustAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("custAddress");
            entity.Property(e => e.CustName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("custName");
        });

        modelBuilder.Entity<KushSbt>(entity =>
        {
            entity.HasKey(e => e.TransId).HasName("PK__kushSBT__DB107FA77FCD876C");

            entity.ToTable("kushSBT");

            entity.Property(e => e.TransId)
                .ValueGeneratedNever()
                .HasColumnName("transId");
            entity.Property(e => e.Accno).HasColumnName("accno");
            entity.Property(e => e.TransDate).HasColumnName("transDate");
            entity.Property(e => e.TransType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("transType");
        });

        modelBuilder.Entity<Muskan>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__muskan__D9509F6DAD5D1BEC");

            entity.ToTable("muskan");

            entity.Property(e => e.Eid)
                .ValueGeneratedNever()
                .HasColumnName("eid");
            entity.Property(e => e.Doj).HasColumnName("doj");
            entity.Property(e => e.Ename)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("ename");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Pragati>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__pragati__DDDFDD36539475D8");

            entity.ToTable("pragati");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Prerna>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Prerna__DDDFDD36204B8DCB");

            entity.ToTable("Prerna");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<PriyankaSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__Priyanka__BE2ACD6E0DCCC692");

            entity.ToTable("PriyankaSBAccount");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PriyankaSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Priyanka__55433A6B0231BAB5");

            entity.ToTable("PriyankaSBTransaction");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.PriyankaSbtransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__PriyankaS__Accou__70A8B9AE");
        });

        modelBuilder.Entity<Sandhya>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Sandhya__DDDFDD36D4582238");

            entity.ToTable("Sandhya");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Sanskriti>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__sanskrit__DDDFDD365FAABCAC");

            entity.ToTable("sanskriti");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<SanskritiSbaccount>(entity =>
        {
            entity.HasKey(e => e.Accno).HasName("PK__SBAccoun__A472931DE837D7A2");

            entity.ToTable("sanskriti_SBAccount");

            entity.Property(e => e.Accno)
                .ValueGeneratedNever()
                .HasColumnName("accno");
            entity.Property(e => e.Cname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cname");
            entity.Property(e => e.CurrAddress)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("curr_address");
            entity.Property(e => e.CurrBalance)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("curr_balance");
        });

        modelBuilder.Entity<SanskritiSbtransaction>(entity =>
        {
            entity.HasKey(e => e.Transid).HasName("PK__SBTransa__DB1F6ABFB65C131A");

            entity.ToTable("sanskriti_SBTransactions");

            entity.Property(e => e.Transid)
                .ValueGeneratedNever()
                .HasColumnName("transid");
            entity.Property(e => e.Accno).HasColumnName("accno");
            entity.Property(e => e.Amt)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("amt");
            entity.Property(e => e.Transdate).HasColumnName("transdate");
            entity.Property(e => e.Transtype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("transtype");

            entity.HasOne(d => d.AccnoNavigation).WithMany(p => p.SanskritiSbtransactions)
                .HasForeignKey(d => d.Accno)
                .HasConstraintName("FK__SBTransac__accno__30C33EC3");
        });

        modelBuilder.Entity<SbAccountv>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__SbAccoun__BE2ACD6E3C187E2F");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SbTransactionv>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__SbTransa__55433A6B1F2EEFE1");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.SbTransactionvs)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__SbTransac__Accou__44CA3770");
        });

        modelBuilder.Entity<SbaccountJay>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__SBAccoun__BE2ACD6E03996350");

            entity.ToTable("SBAccountJay");

            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SbaccountJivanshu>(entity =>
        {
            entity.HasKey(e => e.Accountnumber).HasName("PK__SBAccoun__01565FCBA0B90134");

            entity.ToTable("SBAccountJivanshu");

            entity.Property(e => e.Accountnumber).ValueGeneratedNever();
            entity.Property(e => e.Currentbalance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Customeraddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Customername)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sbaccountivy>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__SBAccoun__BE2ACD6E2498FE1A");

            entity.ToTable("SBAccountivy");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sbtransaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SBtransaction");

            entity.Property(e => e.AccountNo).HasColumnName("account_no");
            entity.Property(e => e.CurrentBalance).HasColumnName("current_balance");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("customer_address");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("customer_name");
        });

        modelBuilder.Entity<SbtransactionJay>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__SBTransa__55433A6B33440E61");

            entity.ToTable("SBTransactionJay");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrancationType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.SbtransactionJays)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("fk");
        });

        modelBuilder.Entity<SbtransactionsJivanshu>(entity =>
        {
            entity.HasKey(e => e.Transactionsid).HasName("PK__SBTransa__B873AF62B3853943");

            entity.ToTable("SBTransactionsJivanshu");

            entity.Property(e => e.Transactionsid).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Transactiondate).HasColumnType("datetime");
            entity.Property(e => e.Transactiontype)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountnumberNavigation).WithMany(p => p.SbtransactionsJivanshus)
                .HasForeignKey(d => d.Accountnumber)
                .HasConstraintName("FK__SBTransac__Accou__3E1D39E1");
        });

        modelBuilder.Entity<Sbtransactionsivy>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__SBTransa__55433A6B6B7B7F8E");

            entity.ToTable("SBTransactionsivy");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.Sbtransactionsivies)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__SBTransac__Accou__6AEFE058");
        });

        modelBuilder.Entity<Shivya>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Shivya__DDDFDD363E4C0512");

            entity.ToTable("Shivya");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Stud>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__stud__DDDFDD3692EC07E2");

            entity.ToTable("stud");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__student__DDDFDD3626AAB5A7");

            entity.ToTable("student");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Student007>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__student0__DDDFDD36718934E4");

            entity.ToTable("student007");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Student1>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__students__DDDFDD3690BE49A9");

            entity.ToTable("students");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Student27>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__student2__DDDFDD3652D91A1D");

            entity.ToTable("student27");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Studentss>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__students__DDDFDD36E67FC708");

            entity.ToTable("studentss");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Studenttt>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__studentt__DDDFDD36046BBB59");

            entity.ToTable("studenttt");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Studentttt>(entity =>
        {
            entity.HasKey(e => e.Siiid).HasName("PK__studentt__3DBE29A1BBC3441F");

            entity.ToTable("studentttt");

            entity.Property(e => e.Siiid)
                .ValueGeneratedNever()
                .HasColumnName("siiid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Suhasini>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__Suhasini__AF4CE865B4F45413");

            entity.ToTable("Suhasini");

            entity.Property(e => e.Empid)
                .ValueGeneratedNever()
                .HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<SuhasiniSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__Suhasini__BE2ACD6EB75B66D3");

            entity.ToTable("Suhasini_SBAccount");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SuhasiniSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Suhasini__55433A6B3801BD95");

            entity.ToTable("Suhasini_SBTransaction");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.SuhasiniSbtransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__Suhasini___Accou__59C55456");
        });

        modelBuilder.Entity<Suhasininew>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__Suhasini__AF4CE865B5D05F55");

            entity.ToTable("Suhasininew");

            entity.Property(e => e.Empid)
                .ValueGeneratedNever()
                .HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Suhasinitable>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__Suhasini__AF4CE865DE4625E0");

            entity.ToTable("Suhasinitable");

            entity.Property(e => e.Empid)
                .ValueGeneratedNever()
                .HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
