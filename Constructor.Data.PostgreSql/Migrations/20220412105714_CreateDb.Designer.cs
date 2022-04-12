﻿// <auto-generated />
using System;
using Constructor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Constructor.Data.PostgreSql.Migrations
{
    [DbContext(typeof(ConstructorDbContext))]
    [Migration("20220412105714_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Constructor.Data.Data.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DomainId")
                        .HasColumnType("integer");

                    b.Property<int>("EntityTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("ScalarValues")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.HasIndex("EntityTypeId");

                    b.ToTable("Entites", (string)null);
                });

            modelBuilder.Entity("Constructor.Data.Data.EntityLink", b =>
                {
                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<int>("EntitySourceId")
                        .HasColumnType("integer");

                    b.Property<int>("EntityTargetId")
                        .HasColumnType("integer");

                    b.HasKey("PropertyId", "EntitySourceId");

                    b.HasIndex("EntitySourceId");

                    b.HasIndex("EntityTargetId");

                    b.ToTable("EntityLinks", (string)null);
                });

            modelBuilder.Entity("Constructor.Data.Data.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DomainId")
                        .HasColumnType("integer");

                    b.Property<int>("EntityTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("RootEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.HasIndex("EntityTypeId");

                    b.HasIndex("RootEntityId");

                    b.ToTable("Models", (string)null);
                });

            modelBuilder.Entity("Constructor.Data.Data.ModelItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("integer");

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<int>("Sequence")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("ModelId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PropertyId");

                    b.ToTable("ModelItems", (string)null);
                });

            modelBuilder.Entity("Constructor.Data.Metadata.Domain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<Guid?>("ComponentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int?>("ParentId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Domains", (string)null);
                });

            modelBuilder.Entity("Constructor.Data.Metadata.EntityProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EntityTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPartOfName")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("Sequence")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EntityTypeId");

                    b.ToTable("EntityProperties", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("EntityProperty");
                });

            modelBuilder.Entity("Constructor.Data.Metadata.EntityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DomainId")
                        .HasColumnType("integer");

                    b.Property<int?>("GroupId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<bool>("IsAbstract")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMasterData")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int?>("ParentId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("PluralName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<byte>("Role")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("EntityTypes", (string)null);
                });

            modelBuilder.Entity("Constructor.Data.Metadata.EntityTypeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DomainId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.ToTable("EntityTypeGroups", (string)null);
                });

            modelBuilder.Entity("DomainEntityType", b =>
                {
                    b.Property<int>("ImportedTypesId")
                        .HasColumnType("integer");

                    b.Property<int>("ImportingDomainsId")
                        .HasColumnType("integer");

                    b.HasKey("ImportedTypesId", "ImportingDomainsId");

                    b.HasIndex("ImportingDomainsId");

                    b.ToTable("EntityTypeImports", (string)null);
                });

            modelBuilder.Entity("Constructor.Data.Metadata.ReferenceEntityProperty", b =>
                {
                    b.HasBaseType("Constructor.Data.Metadata.EntityProperty");

                    b.Property<byte>("DeleteMode")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsSet")
                        .HasColumnType("boolean");

                    b.Property<byte>("ReferenceKind")
                        .HasColumnType("smallint");

                    b.Property<int>("ValueTypeId")
                        .HasColumnType("integer");

                    b.HasIndex("ValueTypeId");

                    b.HasDiscriminator().HasValue("ReferenceEntityProperty");
                });

            modelBuilder.Entity("Constructor.Data.Data.Entity", b =>
                {
                    b.HasOne("Constructor.Data.Metadata.Domain", "Domain")
                        .WithMany("Entities")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Metadata.EntityType", "EntityType")
                        .WithMany("Entities")
                        .HasForeignKey("EntityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domain");

                    b.Navigation("EntityType");
                });

            modelBuilder.Entity("Constructor.Data.Data.EntityLink", b =>
                {
                    b.HasOne("Constructor.Data.Data.Entity", "Source")
                        .WithMany("SourceLinks")
                        .HasForeignKey("EntitySourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Data.Entity", "Target")
                        .WithMany("TargetLinks")
                        .HasForeignKey("EntityTargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Metadata.ReferenceEntityProperty", "Property")
                        .WithMany("EntityLinks")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Source");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("Constructor.Data.Data.Model", b =>
                {
                    b.HasOne("Constructor.Data.Metadata.Domain", "Domain")
                        .WithMany("Models")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Metadata.EntityType", "EntityType")
                        .WithMany("Models")
                        .HasForeignKey("EntityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Data.Entity", "RootEntity")
                        .WithMany()
                        .HasForeignKey("RootEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domain");

                    b.Navigation("EntityType");

                    b.Navigation("RootEntity");
                });

            modelBuilder.Entity("Constructor.Data.Data.ModelItem", b =>
                {
                    b.HasOne("Constructor.Data.Data.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Data.Model", "Model")
                        .WithMany("Items")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Data.ModelItem", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Constructor.Data.Metadata.ReferenceEntityProperty", "Property")
                        .WithMany("ModelItems")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");

                    b.Navigation("Model");

                    b.Navigation("Parent");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Constructor.Data.Metadata.Domain", b =>
                {
                    b.HasOne("Constructor.Data.Metadata.Domain", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Constructor.Data.Metadata.EntityProperty", b =>
                {
                    b.HasOne("Constructor.Data.Metadata.EntityType", "EntityType")
                        .WithMany("Properties")
                        .HasForeignKey("EntityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntityType");
                });

            modelBuilder.Entity("Constructor.Data.Metadata.EntityType", b =>
                {
                    b.HasOne("Constructor.Data.Metadata.Domain", "Domain")
                        .WithMany("EntityTypes")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Metadata.EntityTypeGroup", "Group")
                        .WithMany("EntityTypes")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Metadata.EntityType", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domain");

                    b.Navigation("Group");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Constructor.Data.Metadata.EntityTypeGroup", b =>
                {
                    b.HasOne("Constructor.Data.Metadata.Domain", "Domain")
                        .WithMany("EntityTypeGroups")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("DomainEntityType", b =>
                {
                    b.HasOne("Constructor.Data.Metadata.EntityType", null)
                        .WithMany()
                        .HasForeignKey("ImportedTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Constructor.Data.Metadata.Domain", null)
                        .WithMany()
                        .HasForeignKey("ImportingDomainsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Constructor.Data.Metadata.ReferenceEntityProperty", b =>
                {
                    b.HasOne("Constructor.Data.Metadata.EntityType", "ValueType")
                        .WithMany("ReferenceProperties")
                        .HasForeignKey("ValueTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ValueType");
                });

            modelBuilder.Entity("Constructor.Data.Data.Entity", b =>
                {
                    b.Navigation("SourceLinks");

                    b.Navigation("TargetLinks");
                });

            modelBuilder.Entity("Constructor.Data.Data.Model", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Constructor.Data.Data.ModelItem", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Constructor.Data.Metadata.Domain", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Entities");

                    b.Navigation("EntityTypeGroups");

                    b.Navigation("EntityTypes");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("Constructor.Data.Metadata.EntityType", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Entities");

                    b.Navigation("Models");

                    b.Navigation("Properties");

                    b.Navigation("ReferenceProperties");
                });

            modelBuilder.Entity("Constructor.Data.Metadata.EntityTypeGroup", b =>
                {
                    b.Navigation("EntityTypes");
                });

            modelBuilder.Entity("Constructor.Data.Metadata.ReferenceEntityProperty", b =>
                {
                    b.Navigation("EntityLinks");

                    b.Navigation("ModelItems");
                });
#pragma warning restore 612, 618
        }
    }
}
