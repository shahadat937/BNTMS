import { Role } from './role';

export class User {
  id: any;
  img: string;
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  branchId: string;
  traineeId: string;
  role: Role;
  token?: string;
}
