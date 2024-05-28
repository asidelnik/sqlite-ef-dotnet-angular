import { IUser } from "./IUser";

export interface IInsurancePolicy {
  id: number;
  policyNumber: string;
  insuranceAmount: number;
  startDate: Date;
  endDate: Date;
  userId: number;
  user: IUser;
}
