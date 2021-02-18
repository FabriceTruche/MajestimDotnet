using Majestim._TestBlocks.Resource;

namespace Majestim._TestBlocks.SituTable
{
    public enum SituColumns
    {
        Contrat,

        [Css("center-text"), Label("Période")]
        Periode,

        [Css("center-text"), Label("Date opération")]
        DateOpe,

        [Css("large-text"), Label("Libellé")]
        Libelle,

        [Css("center-text"), Label("Type opération")]
        TypeOpe,

        [Css("large-text")]
        Compte,

        [Css("currency"), Label("Débit")]
        Debit,

        [Css("currency"), Label("Crédit")]
        Credit
    }
}