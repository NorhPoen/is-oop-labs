using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
#pragma warning disable SA1649
public class Initial : SqlMigration
#pragma warning restore SA1649
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table users
    (
        user_id long not null,
        user_password long not null,
        account_balance long not null
    );

    create table transactions
    (
        transaction_id string primary key generated always as identity,
        user_id long not null,
        transaction_amount long not null
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table transactions;
    """;
}