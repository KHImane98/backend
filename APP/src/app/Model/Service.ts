import { Component, Injectable, Input } from "@angular/core";
@Injectable()
export abstract class ServiceRecom {

    @Input() public Id : number | undefined;
    @Input() public UserId : number | undefined;
    @Input() public PhotoUser : string | undefined;
    @Input() public PseudoUser : string | undefined;
    @Input() public Commentaire : string | undefined;
    @Input()
    public Avis!: number | 0;
    @Input() public Status : boolean | undefined;
    @Input() public Created : Date | undefined;
    
}
@Injectable()
export abstract class ServiceDetail {
    @Input() public Id : number | undefined;
    @Input() public Name : string | undefined;
    @Input() public Description : string | undefined;
}