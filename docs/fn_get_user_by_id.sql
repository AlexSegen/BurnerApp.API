CREATE OR REPLACE FUNCTION public.fn_get_user_by_id(userid integer)
 RETURNS json
 LANGUAGE sql
AS $function$

	select to_json(output) from(
	
	select 
		*
	from users
	where	
		id = userid
	
		
 ) as output;

$function$
;
