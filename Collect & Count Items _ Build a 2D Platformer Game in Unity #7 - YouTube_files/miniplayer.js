(function(g){var window=this;'use strict';var gob=function(a,b){g.U.call(this,{I:"button",Na:["ytp-miniplayer-expand-watch-page-button","ytp-button","ytp-miniplayer-button-top-left"],Y:{title:"{{title}}","data-tooltip-target-id":"ytp-miniplayer-expand-watch-page-button","aria-keyshortcuts":"i","data-title-no-tooltip":"{{data-title-no-tooltip}}"},X:[{I:"svg",Y:{height:"24px",version:"1.1",viewBox:"0 0 24 24",width:"24px"},X:[{I:"g",Y:{fill:"none","fill-rule":"evenodd",stroke:"none","stroke-width":"1"},X:[{I:"g",Y:{transform:"translate(12.000000, 12.000000) scale(-1, 1) translate(-12.000000, -12.000000) "},
X:[{I:"path",Y:{d:"M19,19 L5,19 L5,5 L12,5 L12,3 L5,3 C3.89,3 3,3.9 3,5 L3,19 C3,20.1 3.89,21 5,21 L19,21 C20.1,21 21,20.1 21,19 L21,12 L19,12 L19,19 Z M14,3 L14,5 L17.59,5 L7.76,14.83 L9.17,16.24 L19,6.41 L19,10 L21,10 L21,3 L14,3 Z",fill:"#fff","fill-rule":"nonzero"}}]}]}]}]});this.J=a;this.Ta("click",this.onClick,this);this.updateValue("title",g.bV(a,"Expand","i"));this.update({"data-title-no-tooltip":"Expand"});g.ub(this,g.WU(b.Ec(),this.element))},hob=function(a){g.U.call(this,{I:"div",
T:"ytp-miniplayer-ui"});this.qg=!1;this.player=a;this.V(a,"minimized",this.Dh);this.V(a,"onStateChange",this.kR)},iob=function(a){g.IV.call(this,a);
this.B=new g.lL(this);this.j=new hob(this.player);this.j.hide();g.IU(this.player,this.j.element,4);a.vg()&&(this.load(),g.fu(a.getRootNode(),"ytp-player-minimized",!0))};
g.v(gob,g.U);gob.prototype.onClick=function(){this.J.Ua("onExpandMiniplayer")};g.v(hob,g.U);g.k=hob.prototype;
g.k.WN=function(){this.tooltip=new g.hY(this.player,this);g.L(this,this.tooltip);g.IU(this.player,this.tooltip.element,4);this.tooltip.scale=.6;this.hd=new g.oW(this.player);g.L(this,this.hd);this.nk=new g.U({I:"div",T:"ytp-miniplayer-scrim"});g.L(this,this.nk);this.nk.Ga(this.element);this.V(this.nk.element,"click",this.NI);var a=new g.U({I:"button",Na:["ytp-miniplayer-close-button","ytp-button"],Y:{"aria-label":"Close"},X:[g.NG()]});g.L(this,a);a.Ga(this.nk.element);this.V(a.element,"click",this.Fp);
a=new gob(this.player,this);g.L(this,a);a.Ga(this.nk.element);this.hv=new g.U({I:"div",T:"ytp-miniplayer-controls"});g.L(this,this.hv);this.hv.Ga(this.nk.element);this.V(this.hv.element,"click",this.NI);var b=new g.U({I:"div",T:"ytp-miniplayer-button-container"});g.L(this,b);b.Ga(this.hv.element);a=new g.U({I:"div",T:"ytp-miniplayer-play-button-container"});g.L(this,a);a.Ga(this.hv.element);var c=new g.U({I:"div",T:"ytp-miniplayer-button-container"});g.L(this,c);c.Ga(this.hv.element);this.OY=new g.uX(this.player,
this,!1);g.L(this,this.OY);this.OY.Ga(b.element);b=new g.tX(this.player,this);g.L(this,b);b.Ga(a.element);this.nextButton=new g.uX(this.player,this,!0);g.L(this,this.nextButton);this.nextButton.Ga(c.element);this.Ej=new g.aY(this.player,this);g.L(this,this.Ej);this.Ej.Ga(this.nk.element);this.Tc=new g.zX(this.player,this);g.L(this,this.Tc);g.IU(this.player,this.Tc.element,4);this.uI=new g.U({I:"div",T:"ytp-miniplayer-buttons"});g.L(this,this.uI);g.IU(this.player,this.uI.element,4);a=new g.U({I:"button",
Na:["ytp-miniplayer-close-button","ytp-button"],Y:{"aria-label":"Close"},X:[g.NG()]});g.L(this,a);a.Ga(this.uI.element);this.V(a.element,"click",this.Fp);a=new g.U({I:"button",Na:["ytp-miniplayer-replay-button","ytp-button"],Y:{"aria-label":"Close"},X:[g.bua()]});g.L(this,a);a.Ga(this.uI.element);this.V(a.element,"click",this.A8);this.V(this.player,"presentingplayerstatechange",this.Yd);this.V(this.player,"appresize",this.Nb);this.V(this.player,"fullscreentoggled",this.Nb);this.Nb()};
g.k.show=function(){this.Af=new g.St(this.qw,null,this);this.Af.start();this.qg||(this.WN(),this.qg=!0);0!==this.player.getPlayerState()&&g.U.prototype.show.call(this);this.Tc.show();this.player.unloadModule("annotations_module")};
g.k.hide=function(){this.Af&&(this.Af.dispose(),this.Af=void 0);g.U.prototype.hide.call(this);this.player.vg()||(this.qg&&this.Tc.hide(),this.player.loadModule("annotations_module"))};
g.k.Ba=function(){this.Af&&(this.Af.dispose(),this.Af=void 0);g.U.prototype.Ba.call(this)};
g.k.Fp=function(){this.player.stopVideo();this.player.Ua("onCloseMiniplayer")};
g.k.A8=function(){this.player.playVideo()};
g.k.NI=function(a){if(a.target===this.nk.element||a.target===this.hv.element)g.iM(this.player.Tb())?this.player.pauseVideo():this.player.playVideo()};
g.k.Dh=function(){g.fu(this.player.getRootNode(),"ytp-player-minimized",this.player.vg())};
g.k.cf=function(){this.Tc.Ic();this.Ej.Ic()};
g.k.qw=function(){this.cf();this.Af&&this.Af.start()};
g.k.Yd=function(a){g.nH(a.state,32)&&this.tooltip.hide()};
g.k.Nb=function(){g.LX(this.Tc,0,this.player.rb().getPlayerSize().width,!1);g.AX(this.Tc)};
g.k.kR=function(a){this.player.vg()&&(0===a?this.hide():this.show())};
g.k.Ec=function(){return this.tooltip};
g.k.Lg=function(){return!1};
g.k.wg=function(){return!1};
g.k.tm=function(){return!1};
g.k.NJ=function(){};
g.k.qq=function(){};
g.k.Sy=function(){};
g.k.cn=function(){return null};
g.k.iH=function(){return null};
g.k.oN=function(){return new g.we(0,0)};
g.k.Mk=function(){return new g.nr(0,0,0,0)};
g.k.handleGlobalKeyDown=function(){return!1};
g.k.handleGlobalKeyUp=function(){return!1};
g.k.Ew=function(a,b,c,d,e){var f=0,h=d=0,l=g.Br(a);if(b){c=g.au(b,"ytp-prev-button")||g.au(b,"ytp-next-button");var m=g.au(b,"ytp-play-button"),n=g.au(b,"ytp-miniplayer-expand-watch-page-button");c?f=h=12:m?(b=g.zr(b,this.element),h=b.x,f=b.y-12):n&&(h=g.au(b,"ytp-miniplayer-button-top-left"),f=g.zr(b,this.element),b=g.Br(b),h?(h=8,f=f.y+40):(h=f.x-l.width+b.width,f=f.y-20))}else h=c-l.width/2,d=25+(e||0);b=this.player.rb().getPlayerSize().width;e=f+(e||0);l=g.ne(h,0,b-l.width);e?(a.style.top=e+"px",
a.style.bottom=""):(a.style.top="",a.style.bottom=d+"px");a.style.left=l+"px"};
g.k.showControls=function(){};
g.k.Up=function(){};
g.k.jm=function(){return!1};
g.k.eF=function(){};
g.k.SA=function(){};
g.k.Gr=function(){};
g.k.Fr=function(){};
g.k.sy=function(){};
g.k.Ps=function(){};
g.k.OE=function(){};g.v(iob,g.IV);g.k=iob.prototype;g.k.onVideoDataChange=function(){if(this.player.getVideoData()){var a=this.player.getVideoAspectRatio(),b=16/9;a=a>b+.1||a<b-.1;g.fu(this.player.getRootNode(),"ytp-rounded-miniplayer-not-regular-wide-video",a)}};
g.k.create=function(){g.IV.prototype.create.call(this);this.B.V(this.player,"videodatachange",this.onVideoDataChange);this.onVideoDataChange()};
g.k.vl=function(){return!1};
g.k.load=function(){this.player.hideControls();this.j.show()};
g.k.unload=function(){this.player.showControls();this.j.hide()};g.HV("miniplayer",iob);})(_yt_player);
