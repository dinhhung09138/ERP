import { BaseViewModel } from '../../../core/models/base.model';
import { RoleDetailInterface } from './role-detail.interface';

export interface RoleInterface extends BaseViewModel{
    name: string;
    description: string;
    roles: RoleDetailInterface[];
}
