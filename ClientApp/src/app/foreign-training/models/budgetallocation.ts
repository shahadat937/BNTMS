export interface BudgetAllocation {
    getselectedFiscalYear(): unknown;
    budgetAllocationId: number,
    budgetCodeId: number,
    budgetTypeId: number,
    fiscalYearId: number,
    budgetCodeName: string,
    percentage: string,
    amount: string,
    remarks: string,
    menuPosition: number,
    isActive: boolean
}
