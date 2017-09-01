export class Pessoa {
    
    id: number;
    nome: string;
    ativo: boolean;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }

}