
export interface FunctionCommandViewModel {
  id: number;
  functionCode: string;
  name: string;
  isView: boolean;
  moduleName: string;
  controllerName: string;
  actionName: string;
  precedence: number;
  selected: boolean;
}
