import { BaseViewModel } from '../../../core/models/base.model';
import { RoleDetailViewModel } from './role-detail.model';
import { FormActionStatus } from '../../../core/enums/form-action-status.enum';

export class RoleViewModel implements BaseViewModel{
    name: string;
    description: string;
    roles: RoleDetailViewModel[];
    id: number;
    isActive: boolean;
    createDate: Date;
    createBy: number;
    updateDate: Date;
    updateBy: number;
    action: FormActionStatus;
    precedence: number;
    rowVersion: any;
}
