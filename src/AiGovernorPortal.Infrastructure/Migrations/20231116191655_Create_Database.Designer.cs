﻿// <auto-generated />
using System;
using AiGovernorPortal.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AiGovernorPortal.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231116191655_Create_Database")]
    partial class Create_Database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AiGovernorPortal.Domain.AiProxies.AiProxy", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("AiType")
                        .HasColumnType("integer")
                        .HasColumnName("ai_type");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<bool>("IsDynamicallyCreated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_dynamically_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("state");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.HasKey("Id")
                        .HasName("pk_ai_proxies");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_ai_proxies_tenant_id");

                    b.ToTable("ai_proxies", (string)null);
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Features.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int[]>("AiProxies")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("ai_proxies");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid?>("LicenseTemplateId")
                        .HasColumnType("uuid")
                        .HasColumnName("license_template_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("state");

                    b.Property<int[]>("Storage")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("storage");

                    b.HasKey("Id")
                        .HasName("pk_features");

                    b.HasIndex("LicenseTemplateId")
                        .HasDatabaseName("ix_features_license_template_id");

                    b.ToTable("features", (string)null);
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Licenses.License", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("ExpiresOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expires_on_utc");

                    b.Property<DateTime>("GeneratedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("generated_on_utc");

                    b.Property<Guid>("LicenseTemplateId")
                        .HasColumnType("uuid")
                        .HasColumnName("license_template_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.HasKey("Id")
                        .HasName("pk_licenses");

                    b.HasIndex("LicenseTemplateId")
                        .HasDatabaseName("ix_licenses_license_template_id");

                    b.HasIndex("TenantId")
                        .IsUnique()
                        .HasDatabaseName("ix_licenses_tenant_id");

                    b.ToTable("licenses", (string)null);
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Licenses.LicenseTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<byte>("DurationInMonths")
                        .HasColumnType("smallint")
                        .HasColumnName("duration_in_months");

                    b.Property<TimeSpan>("DurationMonths")
                        .HasColumnType("interval")
                        .HasColumnName("duration_months");

                    b.HasKey("Id")
                        .HasName("pk_license_templates");

                    b.ToTable("license_templates", (string)null);
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Tenants.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("ActivatedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("activated_on_utc");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on_utc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Subdomain")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("subdomain");

                    b.Property<DateTime?>("TerminatedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("terminated_on_utc");

                    b.HasKey("Id")
                        .HasName("pk_tenants");

                    b.ToTable("tenants", (string)null);
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Vaults.Vault", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("SizeInMb")
                        .HasColumnType("integer")
                        .HasColumnName("size_in_mb");

                    b.Property<int>("StorageState")
                        .HasColumnType("integer")
                        .HasColumnName("storage_state");

                    b.Property<int>("StorageType")
                        .HasColumnType("integer")
                        .HasColumnName("storage_type");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.HasKey("Id")
                        .HasName("pk_vaults");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_vaults_tenant_id");

                    b.ToTable("vaults", (string)null);
                });

            modelBuilder.Entity("AiGovernorPortal.Infrastructure.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("json")
                        .HasColumnName("content");

                    b.Property<string>("Error")
                        .HasColumnType("text")
                        .HasColumnName("error");

                    b.Property<DateTime>("OccurredOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("occurred_on_utc");

                    b.Property<DateTime?>("ProcessedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("processed_on_utc");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_outbox_messages");

                    b.ToTable("outbox_messages", (string)null);
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.AiProxies.AiProxy", b =>
                {
                    b.HasOne("AiGovernorPortal.Domain.Tenants.Tenant", null)
                        .WithMany("AiProxies")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("fk_ai_proxies_tenant_tenant_temp_id");
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Features.Feature", b =>
                {
                    b.HasOne("AiGovernorPortal.Domain.Licenses.LicenseTemplate", null)
                        .WithMany("Features")
                        .HasForeignKey("LicenseTemplateId")
                        .HasConstraintName("fk_features_license_template_license_template_temp_id1");
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Licenses.License", b =>
                {
                    b.HasOne("AiGovernorPortal.Domain.Licenses.LicenseTemplate", "LicenseTemplate")
                        .WithMany()
                        .HasForeignKey("LicenseTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_licenses_license_template_license_template_temp_id");

                    b.HasOne("AiGovernorPortal.Domain.Tenants.Tenant", null)
                        .WithOne("License")
                        .HasForeignKey("AiGovernorPortal.Domain.Licenses.License", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_licenses_tenants_tenant_id");

                    b.Navigation("LicenseTemplate");
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Tenants.Tenant", b =>
                {
                    b.OwnsOne("AiGovernorPortal.Domain.Tenants.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("TenantId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("address")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("contact_address");

                            b1.Property<string>("company")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("contact_company");

                            b1.Property<string>("email")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("contact_email");

                            b1.HasKey("TenantId");

                            b1.ToTable("tenants");

                            b1.WithOwner()
                                .HasForeignKey("TenantId")
                                .HasConstraintName("fk_tenants_tenants_id");
                        });

                    b.Navigation("Contact")
                        .IsRequired();
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Vaults.Vault", b =>
                {
                    b.HasOne("AiGovernorPortal.Domain.Tenants.Tenant", null)
                        .WithMany("Vaults")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("fk_vaults_tenants_tenant_id");
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Licenses.LicenseTemplate", b =>
                {
                    b.Navigation("Features");
                });

            modelBuilder.Entity("AiGovernorPortal.Domain.Tenants.Tenant", b =>
                {
                    b.Navigation("AiProxies");

                    b.Navigation("License")
                        .IsRequired();

                    b.Navigation("Vaults");
                });
#pragma warning restore 612, 618
        }
    }
}
