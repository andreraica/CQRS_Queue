using Domain.General.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.General.Mappings
{
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.ToTable("ComercializacaoEvento");

            builder.Property(c => c.Id)
                .HasColumnName("id_ComercializacaoEvento");

            builder.Property(c => c.AggregateId)
               .HasColumnName("id_Agregador");


            builder.Property(c => c.MessageType)
                .HasColumnName("tx_Acao")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Data)
                .HasColumnName("lx_Dado");

            builder.Property(c => c.User)
                .HasColumnName("lx_Usuario");

            builder.Property(c => c.Timestamp)
              .HasColumnName("dt_Cadastro");

            builder.Property(c => c.SagaId)
                .HasColumnName("id_Saga");

        }
    }
}
