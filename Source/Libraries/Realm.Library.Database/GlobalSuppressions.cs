// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the
// Error List, point to "Suppress Message(s)", and click
// "In Project Suppression File".
// You do not need to add suppressions to this file manually.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "1#", Scope = "member", Target = "Realm.Library.Database.IDatabaseWrapper.#Execute(System.String,System.Data.DataTable&,System.Collections.Generic.IDictionary`2<System.String,System.Object>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "1#", Scope = "member", Target = "Realm.Library.Database.IProcedure.#Execute(System.Data.IDbCommand,System.Data.DataTable&,System.Collections.Generic.IDictionary`2<System.String,System.Object>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Scope = "member", Target = "Realm.Library.Database.TextProcedure`1.#Execute(System.Data.IDbCommand,System.Data.DataTable&,System.Collections.Generic.IDictionary`2<System.String,System.Object>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]