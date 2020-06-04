import { BaseViewModel } from 'src/app/core/models/base.mode';

export interface StudyViewModal extends BaseViewModel {
    name: string;
    precedence: number;
  }