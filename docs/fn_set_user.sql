CREATE OR REPLACE FUNCTION public.fn_set_user(userid integer, iname character varying, iusername character varying, iemail character varying, iphone character varying, iwebsite character varying)
 RETURNS SETOF json
 LANGUAGE plpgsql
AS $function$
DECLARE
    salida json;
BEGIN

	if exists(select 1 from users where id = userid or userid <> 0)  then

		update users set name = iname, username = iusername, email = iemail, phone = iphone, website = iwebsite where id = userid;
		
	else
	
		insert into users
		(name,username,email,phone,website) 
		values
		(iname,iusername,iemail,iphone,iwebsite);
	
	end if;
	
	return query (SELECT fn_get_user_by_id(userid));

END;
$function$
;
