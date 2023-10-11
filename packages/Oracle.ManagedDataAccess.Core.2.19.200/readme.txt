Oracle.ManagedDataAccess.Core NuGet Package 2.19.200 README
===========================================================
Release Notes: Oracle Data Provider for .NET Core

July 2023

This provider supports .NET 6 & .NET 7.

This document provides information that supplements the Oracle Data Provider for .NET (ODP.NET) documentation.

You have downloaded Oracle Data Provider for .NET. The license agreement is available here:
https://www.oracle.com/downloads/licenses/distribution-license.html


Bug Fixes since Oracle.ManagedDataAccess.Core NuGet Package 2.19.190
====================================================================
Bug 34722758 - EXECUTEXMLREADER RESULTS IN ORA-01006: BIND VARIABLE DOES NOT EXIST
Bug 35266943 - LDAP LOOK-UP/FILTERING ISSUE WHEN DEFAULT_ADMIN_CONTEXT IS NOT SET IN LDAP.ORA
Bug 35296986 - GETCOLUMNSCHEMA() THROWS ORA-00942 TABLE DOES NOT EXIST WITH PARAMETERIZED OFFSET
Bug 35303226 - USING DISTRIBUTED TRANSACTION RESULTS IN STACKOVERFLOWEXCEPTION
Bug 35325024 - ODPM/C TO USE FULL CERTIFICATE (WITH PRIVATE KEY) WHEN MTLS IS USED
Bug 35335650 - PERFORMANCE ISSUE WITH CONNECTION OPEN/CLOSE WITH LOAD
Bug 35392277 - DST OBSERVANCE CHANGE IN MEXICO_CITY TIMEZONE NOT RECOGNIZED
Bug 35392765 - ORA-00542: FAILURE DURING SSL HANDSHAKE


Known Issues and Limitations
============================
1) BindToDirectory throws NullReferenceException on Linux when LdapConnection AuthType is Anonymous

https://github.com/dotnet/runtime/issues/61683

This issue is observed when using System.DirectoryServices.Protocols, version 6.0.0.
To workaround the issue, use System.DirectoryServices.Protocols, version 5.0.1.

 Copyright (c) 2021, 2023, Oracle and/or its affiliates. 
