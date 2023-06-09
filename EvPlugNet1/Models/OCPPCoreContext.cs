﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EvPlugNet1.Models;

public partial class OCPPCoreContext : DbContext
{
    public OCPPCoreContext(DbContextOptions<OCPPCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<ChargePoint> ChargePoints { get; set; }

    public virtual DbSet<ChargePointNode> ChargePointNodes { get; set; }

    public virtual DbSet<ChargeTag> ChargeTags { get; set; }

    public virtual DbSet<ConnectorStatus> ConnectorStatuses { get; set; }

    public virtual DbSet<ConnectorStatusView> ConnectorStatusViews { get; set; }

    public virtual DbSet<MessageLog> MessageLogs { get; set; }

    public virtual DbSet<Node> Nodes { get; set; }

    public virtual DbSet<Node2node> Node2nodes { get; set; }

    public virtual DbSet<NodeType> NodeTypes { get; set; }

    public virtual DbSet<Nodes2charger> Nodes2chargers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<UserCharger> UserChargers { get; set; }

    public virtual DbSet<UserNode> UserNodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.RoleId).IsRequired();

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.LoginProvider)
                .IsRequired()
                .HasMaxLength(128);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(128);
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);
        });

        modelBuilder.Entity<ChargePoint>(entity =>
        {
            entity.HasKey(e => e.ChargePointId).HasName("PK_ChargePoint_1");

            entity.ToTable("ChargePoint");

            entity.HasIndex(e => e.ChargePointId, "ChargePoint_Identifier").IsUnique();

            entity.Property(e => e.ChargePointId).HasMaxLength(100);
            entity.Property(e => e.ClientCertThumb).HasMaxLength(100);
            entity.Property(e => e.Comment).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<ChargePointNode>(entity =>
        {
            entity.ToTable("ChargePointNode");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChargePointId).HasMaxLength(100);
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ChargeTag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK_ChargeKeys");

            entity.Property(e => e.TagId).HasMaxLength(50);
            entity.Property(e => e.ParentTagId).HasMaxLength(50);
            entity.Property(e => e.TagName).HasMaxLength(200);
        });

        modelBuilder.Entity<ConnectorStatus>(entity =>
        {
            entity.HasKey(e => new { e.ChargePointId, e.ConnectorId });

            entity.ToTable("ConnectorStatus");

            entity.Property(e => e.ChargePointId).HasMaxLength(100);
            entity.Property(e => e.ConnectorName).HasMaxLength(100);
            entity.Property(e => e.LastStatus).HasMaxLength(100);
        });

        modelBuilder.Entity<ConnectorStatusView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ConnectorStatusView");

            entity.Property(e => e.ChargePointId)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ConnectorName).HasMaxLength(100);
            entity.Property(e => e.LastStatus).HasMaxLength(100);
            entity.Property(e => e.StartResult).HasMaxLength(100);
            entity.Property(e => e.StartTagId).HasMaxLength(50);
            entity.Property(e => e.StopReason).HasMaxLength(100);
            entity.Property(e => e.StopTagId).HasMaxLength(50);
        });

        modelBuilder.Entity<MessageLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("MessageLog");

            entity.HasIndex(e => e.LogTime, "IX_MessageLog_ChargePointId");

            entity.Property(e => e.ChargePointId)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ErrorCode).HasMaxLength(100);
            entity.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Node>(entity =>
        {
            entity.ToTable("Node");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChargePointId)
                .HasMaxLength(100)
                .HasColumnName("chargePointId");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateCreate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StringLocation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("stringLocation");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Node2node>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_node2node");

            entity.ToTable("Node2node");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<NodeType>(entity =>
        {
            entity.ToTable("NodeType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datedreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("datedreate");
            entity.Property(e => e.NodeType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nodeType");
        });

        modelBuilder.Entity<Nodes2charger>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("nodes2chargers");

            entity.Property(e => e.ChargePointId)
                .HasMaxLength(100)
                .HasColumnName("chargePointId");
            entity.Property(e => e.Cpid)
                .HasMaxLength(100)
                .HasColumnName("cpid");
            entity.Property(e => e.DateCreate)
                .HasColumnType("datetime")
                .HasColumnName("dateCreate");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StringLocation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("stringLocation");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Role");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateCreate");
            entity.Property(e => e.Int)
                .ValueGeneratedOnAdd()
                .HasColumnName("int");
            entity.Property(e => e.RoleDesc).HasMaxLength(50);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.ChargePointId)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.StartResult).HasMaxLength(100);
            entity.Property(e => e.StartTagId).HasMaxLength(50);
            entity.Property(e => e.StopReason).HasMaxLength(100);
            entity.Property(e => e.StopTagId).HasMaxLength(50);
            entity.Property(e => e.Uid).HasMaxLength(50);

            entity.HasOne(d => d.ChargePoint).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ChargePointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_ChargePoint");
        });

        modelBuilder.Entity<UserCharger>(entity =>
        {
            entity.ToTable("UserCharger");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChargePointId).HasMaxLength(100);
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateCreate");
            entity.Property(e => e.UserId).HasMaxLength(450);
        });

        modelBuilder.Entity<UserNode>(entity =>
        {
            entity.ToTable("UserNode");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateCreate");
            entity.Property(e => e.Node).HasColumnName("node");
            entity.Property(e => e.SystemUser)
                .HasMaxLength(450)
                .HasColumnName("systemUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}