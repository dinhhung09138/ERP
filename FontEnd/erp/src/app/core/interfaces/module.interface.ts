import { FunctionInterface } from './function.interface';

export interface ModuleInterface {
  code: string;
  name: string;
  url: string;
  icon: string;
  parentCode: string;
  precedence: number;
  functions: FunctionInterface[];
}
